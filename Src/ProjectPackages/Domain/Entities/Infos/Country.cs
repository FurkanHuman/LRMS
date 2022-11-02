using Core.Domain.Abstract;
using Core.Domain.Bases;

namespace Domain.Entities.Infos;

public class Country : BaseEntity<int>, IEntity
{
    public string CountryCode { get; set; }

    public IList<City> Cities { get; set; }
}