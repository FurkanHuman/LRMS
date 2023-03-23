// this file was created automatically.

using Core.Application.Dtos;

namespace Application.Features.Cities.Queries.GetListByCity;

public class GetListByCityResponse : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CountryCode { get; set; }
    public bool IsDeleted { get; set; }
}
