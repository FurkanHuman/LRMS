// this file was created automatically.
using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.Languages.Commands.DeleteLanguage;
using Application.Features.Languages.Commands.UpdateLanguage;
using Application.Features.Languages.Queries.GetByIdLanguage;
using Application.Features.Languages.Queries.GetListByLanguage;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.Infos;

namespace Application.Features.Languages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Language, CreateLanguageCommand>().ReverseMap();
        CreateMap<Language, CreatedLanguageResponse>().ReverseMap();
        
        CreateMap<Language, DeleteLanguageCommand>().ReverseMap();
        CreateMap<Language, DeletedLanguageResponse>().ReverseMap();

        CreateMap<Language, UpdateLanguageCommand>().ReverseMap();
        CreateMap<Language, UpdatedLanguageResponse>().ReverseMap();

        CreateMap<Language, GetByIdLanguageResponse>().ReverseMap();

        CreateMap<Language, GetListByLanguageResponse>().ReverseMap();
        CreateMap<IPaginate<Language>, GetListResponse<GetListByLanguageResponse>>().ReverseMap();
    }
}
