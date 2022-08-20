using Blog.Api.Model;
using Blog.Api.Repository;

namespace Blog.Api.Services;

public class PublicationService
{
    private readonly IPublicationRepository _publicationRepository;
    public PublicationService(IPublicationRepository publicationRepository)
    {
        _publicationRepository = publicationRepository;
    }

    public string CreatePublication(Publication publication)
    {
        _publicationRepository.Add(publication);
        return "Publicação criada.";
    }

    public string EditPublication(int id, Publication publication)
    {
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

    public IEnumerable<Publication> ListPublication()
    {
        return _publicationRepository.List();
    }

    public Publication DetailPublication(int id)
    {
        var publication = _publicationRepository.GetById(id);
        return publication;
    }
}