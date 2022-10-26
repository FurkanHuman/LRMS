using Entities.Enums;

namespace Entities.Concrete.Entities.Infos
{
    public class CloudStorageService : BaseEntity<uint>, IEntity
    {
        public string SubDomain { get; set; }

        public bool IsActive { get; set; }

        public CloudStorageServiceTransferType ServiceTransferType { get; set; }
 
        public Continent Continent { get; set; }

        public IList<Image> Images { get; set; }
        public IList<EMaterialFile> EMaterialFiles { get; set; }
    }
}