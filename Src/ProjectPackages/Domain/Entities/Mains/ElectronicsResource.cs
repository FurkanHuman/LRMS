using Core.Domain.Abstract;
using Domain.Entities.Bases;
using Domain.Entities.Infos;

namespace Domain.Entities.Mains;

public class ElectronicsResource : MaterialBase, IEntity // elec res type add a enum Todo
{
    public string ResourceUrl { get; set; }

    public IList<CloudStorage> CloudStorageService { get; set; }
    public IList<Kit> Kits { get; set; }
}