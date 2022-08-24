using System.Dynamic;
using AutoMapper;
using Blog.Api.Dto;
using Blog.Api.Enums;
using Blog.Api.Exceptions;
using Blog.Api.Model;
using Blog.Api.Repository;

namespace Blog.Api.Services;

public class PublicationService
{
    private readonly IMapper _mapper;
    private readonly IPublicationRepository _publicationRepository;
    public PublicationService(IPublicationRepository publicationRepository, IMapper mapper)
    {
        _publicationRepository = publicationRepository;
        _mapper = mapper;
    }

    public async Task CreatePublication(CreatePublicationDto createPublicationDto)
    {
        var titleExceptionCheck = await _publicationRepository.GetByTitle(createPublicationDto.Title!);
        if (titleExceptionCheck != null)
            throw new ErrorException(StatusCodes.Status400BadRequest, "Já existe uma publicação com mesmo título.");

        var publication = _mapper.Map<Publication>(createPublicationDto);
        _publicationRepository.Add(publication);
    }

    public async Task EditPublication(int id, EditPublicationDto editPublicationDto)
    {
        if (id != editPublicationDto.PublicationId)
            throw new ErrorException(StatusCodes.Status400BadRequest, "Os Ids não conferem.");

        var idExceptionCheck = await _publicationRepository.GetById(editPublicationDto.PublicationId);
        if (idExceptionCheck == null)
            throw new ErrorException(StatusCodes.Status400BadRequest, "Não existe publicação com esse Id.");

        var titleExceptionCheck = await _publicationRepository.GetByTitle(editPublicationDto.Title!);
        if (titleExceptionCheck != null)
            throw new ErrorException(StatusCodes.Status400BadRequest, "Já existe uma outra publicação com mesmo título.");

        var publication = _mapper.Map<Publication>(editPublicationDto);
        _publicationRepository.Update(publication);
    }

    public async Task DeletePublication(int id)
    {
        var publication = await _publicationRepository.GetById(id);
        if (publication == null)
            throw new ErrorException(StatusCodes.Status400BadRequest, "Não existe publicação com esse Id.");

        _publicationRepository.Delete(publication);
    }

    public async Task<dynamic> ListPublication(
        int pageNumber = 1,
        int pageSize = 3,
        string? search = "",
        OrderByPublicationColumnEnum orderByCollumn = OrderByPublicationColumnEnum.PublicationId,
        OrderByTypeEnum orderByType = OrderByTypeEnum.ASC
    )
    {
        var listPublication = await _publicationRepository.List(pageNumber, pageSize, search!, orderByCollumn, orderByType);

        dynamic result = new ExpandoObject();
        result.pageNumber = pageNumber;
        result.pageSize = pageSize;
        result.totalPages = Math.Ceiling((double)listPublication.TotalItemCount / pageSize);
        result.totalItems = listPublication.TotalItemCount;
        result.search = search;
        result.orderByCollumn = orderByCollumn;
        result.orderByType = orderByType;
        result.data = _mapper.Map<List<ListPublicationDto>>(listPublication);

        return result;
    }

    public async Task<DetailPublicationDto> DetailPublication(int id)
    {
        var publication = await _publicationRepository.GetById(id);
        if (publication == null)
            throw new ErrorException(StatusCodes.Status400BadRequest, "Não existe publicação com esse Id.");

        return _mapper.Map<DetailPublicationDto>(publication);
    }
}