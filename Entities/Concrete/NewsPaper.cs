using Core.Entities.Abstract;
using Entities.Concrete.Base;

namespace Entities.Concrete
{
    public class NewsPaper : BasePaper, IEntity
    {
        public DateTime Date { get; set; }
    }
}
