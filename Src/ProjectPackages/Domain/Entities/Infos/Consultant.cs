using Core.Domain.Abstract;
using Domain.Entities.Bases;
using Domain.Entities.Mains;

namespace Domain.Entities.Infos;

public class Consultant : FirstPagePersonBase, IEntity
{
    public string? NamePreAttachment { get; set; }

    public IList<Thesis> Theses { get; set; }
}
