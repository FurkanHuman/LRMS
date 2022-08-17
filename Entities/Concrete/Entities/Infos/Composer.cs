using Core.Entities.Abstract;
using Entities.Concrete.Entities.Bases;
using Entities.Concrete.Entities.Mains;

namespace Entities.Concrete.Entities.Infos
{
    public class Composer : FirstPagePersonBase, IEntity
    {
        public string? NamePreAttachment { get; set; }

        public IList<MusicalNote> MusicalNotes { get; set; }
    }
}