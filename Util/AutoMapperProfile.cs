using AutoMapper;
using Blog.Api.Dto;
using Blog.Api.Model;

namespace Blog.Api.Util;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Comment, CreateCommentDto>().ReverseMap();
        CreateMap<Comment, DetailCommentDto>().ReverseMap();
        CreateMap<Publication, CreatePublicationDto>().ReverseMap();
        CreateMap<Publication, DetailPublicationDto>().ReverseMap();
        CreateMap<Publication, EditPublicationDto>().ReverseMap();
        CreateMap<Publication, ListPublicationDto>().ReverseMap();
    }
}