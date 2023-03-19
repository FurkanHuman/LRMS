// this file was created automatically.

using Core.Application.Dtos;

namespace Application.Features.Countries.Queries.GetListByCountry;

public class GetListByCountryResponse : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CountryCode { get; set; }
    public IList<string> CitiesName { get; set; }
}
