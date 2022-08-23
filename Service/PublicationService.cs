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

    public string CreatePublication(CreatePublicationDto createPublicationDto)
    {
        var titleExceptionCheck = _publicationRepository.GetByTitle(createPublicationDto.Title!);
        if (titleExceptionCheck != null)
            throw new ErrorException(StatusCodes.Status400BadRequest, "Já existe uma publicação com mesmo título.");

        var publication = _mapper.Map<Publication>(createPublicationDto);
        _publicationRepository.Add(publication);
        return "Publicação criada.";
    }

    public string EditPublication(int id, EditPublicationDto editPublicationDto)
    {
        if (id != editPublicationDto.PublicationId)
            throw new ErrorException(StatusCodes.Status400BadRequest, "Os Ids não conferem.");

        var idExceptionCheck = _publicationRepository.GetById(editPublicationDto.PublicationId);
        if (idExceptionCheck == null)
            throw new ErrorException(StatusCodes.Status400BadRequest, "Não existe publicação com esse Id.");

        var titleExceptionCheck = _publicationRepository.GetByTitle(editPublicationDto.Title!);
        if (titleExceptionCheck != null)
            throw new ErrorException(StatusCodes.Status400BadRequest, "Já existe uma outra publicação com mesmo título.");

        var publication = _mapper.Map<Publication>(editPublicationDto);
        _publicationRepository.Update(publication);
        return "Publicação atualizada.";
    }

    public string DeletePublication(int id)
    {
        var publication = _publicationRepository.GetById(id);
        if (publication == null)
            throw new ErrorException(StatusCodes.Status400BadRequest, "Não existe publicação com esse Id.");

        _publicationRepository.Delete(publication);
        return "Publicação removida.";
    }

    public dynamic ListPublication(
        int pageNumber = 1,
        int pageSize = 5,
        string? search = "",
        OrderByPublicationColumnEnum orderByCollumn = OrderByPublicationColumnEnum.PublicationId,
        OrderByTypeEnum orderByType = OrderByTypeEnum.ASC
    )
    {
        var listPublication = _publicationRepository.List(pageNumber, pageSize, search!, orderByCollumn, orderByType);

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

    public DetailPublicationDto DetailPublication(int id)
    {
        var publication = _publicationRepository.GetById(id);
        if (publication == null)
            throw new ErrorException(StatusCodes.Status400BadRequest, "Não existe publicação com esse Id.");

        return _mapper.Map<DetailPublicationDto>(publication);
    }
}