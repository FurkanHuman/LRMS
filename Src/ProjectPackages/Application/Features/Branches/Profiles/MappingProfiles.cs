// this file was created automatically.
using Application.Features.Branches.Commands.UpdateBranch;
using Application.Features.Branches.Queries.GetByIdBranch;
using Application.Features.Branches.Queries.GetListByBranch;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.Infos;

namespace Application.Features.Branches.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Branch, GetByIdBranchResponse>().ReverseMap();

        CreateMap<Branch, GetListByBranchResponse>().ReverseMap();

        CreateMap<IPaginate<Branch>, GetListResponse<GetListByBranchResponse>>().ReverseMap();
    }
}
