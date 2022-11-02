using Core.Domain.Abstract;
using Core.Domain.Bases;

namespace Domain.Entities.Infos;

public class City : BaseEntity<int>, IEntity
{
    public int CountryId { get; set; }

    public Country Country { get; set; }
}