// this file was created automatically.
using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Commands.DeleteCategory;
using Application.Features.Categories.Commands.UpdateCategory;
using Application.Features.Categories.Queries.GetByIdCategory;
using Application.Features.Categories.Queries.GetListByCategory;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.Infos;

namespace Application.Features.Categories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Category, CreateCategoryCommand>().ReverseMap();
        CreateMap<Category, CreatedCategoryResponse>().ReverseMap();

        CreateMap<Category, DeleteCategoryCommand>().ReverseMap();
        CreateMap<Category, DeletedCategoryResponse>().ReverseMap();

        CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
        CreateMap<Category, UpdatedCategoryResponse>().ReverseMap();

        CreateMap<Category, GetByIdCategoryResponse>().ReverseMap();

        CreateMap<Category, GetListByCategoryResponse>().ReverseMap();
        CreateMap<IPaginate<Category>, GetListResponse<GetListByCategoryResponse>>().ReverseMap();
    }
}
