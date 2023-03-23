// this file was created automatically.

using Core.Application.Dtos;

namespace Application.Features.Cities.Commands.CreateCity;

public class CreatedCityResponse : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CountryName { get; set; }

}
