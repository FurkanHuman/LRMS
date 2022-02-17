using Core.Entities.Abstract;
using Entities.Concrete.Base;

namespace Entities.Concrete
{
    public class AudioRecord : MaterialBase, IEntity
    {
        public DateTime RecordDate { get; set; }
    }
}
