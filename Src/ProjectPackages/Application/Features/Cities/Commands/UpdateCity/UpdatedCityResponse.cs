// this file was created automatically.

using Core.Application.Dtos;

namespace Application.Features.Cities.Commands.UpdateCity;

public class UpdatedCityResponse : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CountryName { get; set; }
}
