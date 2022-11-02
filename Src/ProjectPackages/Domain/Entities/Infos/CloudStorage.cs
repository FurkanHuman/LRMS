using Core.Domain.Abstract;
using Core.Domain.Bases;
using Domain.Enums;

namespace Domain.Entities.Infos;

public class CloudStorage : BaseEntity<uint>, IEntity
{
    public string CompanyName { get; set; }

    public string SubDomain { get; set; }

    public bool IsActive { get; set; }

    public CloudStorageTransferType CloudStorageTransferType { get; set; }

    public Continent Continent { get; set; }

    public IList<Image> Images { get; set; }
    public IList<EMaterialFile> EMaterialFiles { get; set; }
}