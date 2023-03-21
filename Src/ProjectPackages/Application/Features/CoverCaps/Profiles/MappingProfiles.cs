// this file was created automatically.
using Application.Features.CoverCaps.Commands.CreateCoverCap;
using Application.Features.CoverCaps.Commands.DeleteCoverCap;
using Application.Features.CoverCaps.Commands.UpdateCoverCap;
using Application.Features.CoverCaps.Queries.GetByIdCoverCap;
using Application.Features.CoverCaps.Queries.GetListByCoverCap;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.Infos;

namespace Application.Features.CoverCaps.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CoverCap, CreateCoverCapCommand>().ReverseMap();
        CreateMap<CoverCap, CreatedCoverCapResponse>().ReverseMap();

        CreateMap<CoverCap, DeleteCoverCapCommand>().ReverseMap();
        CreateMap<CoverCap, DeletedCoverCapResponse>().ReverseMap();

        CreateMap<CoverCap, UpdateCoverCapCommand>().ReverseMap();
        CreateMap<CoverCap, UpdatedCoverCapResponse>().ReverseMap();

        CreateMap<CoverCap, GetByIdCoverCapResponse>().ReverseMap();

        CreateMap<CoverCap, GetListByCoverCapResponse>().ReverseMap();

        CreateMap<IPaginate<CoverCap>, GetListResponse<GetListByCoverCapResponse>>().ReverseMap();
    }
}
