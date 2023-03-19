// this file was created automatically.

using Core.Application.Dtos;

namespace Application.Features.Countries.Commands.DeleteCountry;

public class DeletedCountryResponse : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CountryCode { get; set; }
}
