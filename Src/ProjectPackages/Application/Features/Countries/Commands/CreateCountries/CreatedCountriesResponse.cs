// this file was created automatically.

using Core.Application.Dtos;

namespace Application.Features.Countries.Commands.CreateCountries;

public class CreatedCountriesResponse : IDto
{
    public IList<CreatedCountriesResponseHeader> CreatedCountries { get; set; }
}
