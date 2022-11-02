using Core.Domain.Abstract;
using Domain.Entities.Bases;
using Domain.Entities.Mains;

namespace Domain.Entities.Infos;

public class Composer : FirstPagePersonBase, IEntity
{
    public string? NamePreAttachment { get; set; }

    public IList<MusicalNote> MusicalNotes { get; set; }
}