// this file was created automatically.

using Core.Application.Dtos;
using Domain.Entities.Infos;

namespace Application.Features.Countries.Queries.GetByIdCountry;

public class GetByIdCountryResponse : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CountryCode { get; set; }
    public IList<string> CitiesName { get; set; }
}
