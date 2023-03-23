// this file was created automatically.

using Core.Application.Dtos;

namespace Application.Features.Cities.Queries.GetByIdCity;

public class GetByIdCityResponse : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CountryName { get; set; }
    public bool IsDeleted { get; set; }
}
