// this file was created automatically.
using Domain.Entities.Infos;

namespace Application.Features.Countries.Constants;

public static class CountryMessages
{
    internal static readonly string CountryNameIsExit = "Country Name Is Exit";
    internal static readonly string CountryCodeIsExit = "Country Code Is Exit";
    internal static readonly string CountryIdNotExit = "Country Id Not Exit";

    internal static string MultiExit(IList<Country> countries)
    {
        return string.Join(", ", countries.Select(c => c.Name) + ", " + countries.Select(c => c.CountryCode) + " Is exist");
    }
}