using Core.Domain.Abstract;
using PluralizeService.Core;
using System.Reflection;

List<string> allTypes = new();

allTypes.AddRange(GetIEntities("Core.Domain"));
allTypes.AddRange(GetIEntities("Domain"));

foreach (string type in allTypes)
{
    string pluralWord = PluralizationProvider.Pluralize(type);
    Console.WriteLine(pluralWord);
}

Console.WriteLine("Count : "+allTypes.Count);

static IList<string> GetIEntities(string loadPack)
{
    Assembly assembly = Assembly.Load(loadPack);

    return assembly.GetTypes()
         .Where(x => typeof(IEntity).IsAssignableFrom(x) && x.IsClass)
         .Select(o => o.Name).ToList();
}