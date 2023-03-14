using Core.Domain.Abstract;
using PluralizeService.Core;
using System.Reflection;

IList<Type> allTypes = GetIEntities("Domain");

//allTypes.AddRange(GetIEntities("Core.Domain"));


foreach (Type type in allTypes)
{
    Console.WriteLine($@"services.AddScoped<I{type.Name}Repository, {type.Name}Repository>();");
}

Console.WriteLine("Count : "+allTypes.Count);

static IList<Type> GetIEntities(string loadPack)
{
    Assembly assembly = Assembly.Load(loadPack);

    return assembly.GetTypes().Where(x => typeof(IEntity).IsAssignableFrom(x) && x.IsClass&&x.Namespace == "Domain.Entities.Infos").ToList();
}