using AutoMapper;
using Blog.Api.Dto;
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
        var publication = _mapper.Map<Publication>(createPublicationDto);
        _publicationRepository.Add(publication);
        return "Publicação criada.";
    }

    public string EditPublication(int id, EditPublicationDto editPublicationDto)
    {
        var publication = _mapper.Map<Publication>(editPublicationDto);
        _publicationRepository.Update(publication);
        return "Publicação atualizada.";
    }

    public string DeletePublication(int id)
    {
        var publication = _publicationRepository.GetById(id);
        if (publication == null) return "Não existe publicação com esse Id.";
        _publicationRepository.Delete(publication);
        return "Publicação removida.";
    }

    public IEnumerable<ListPublicationDto> ListPublication()
    {
        var result = _publicationRepository.List();
        return _mapper.Map<IEnumerable<ListPublicationDto>>(result);
    }

    public DetailPublicationDto DetailPublication(int id)
    {
        var publication = _publicationRepository.GetById(id);
        return _mapper.Map<DetailPublicationDto>(publication);
    }
}