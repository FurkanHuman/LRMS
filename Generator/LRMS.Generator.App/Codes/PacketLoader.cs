using Core.Domain.Abstract;
using System.Diagnostics;
using System.Reflection;

namespace LRMS.Generator.App.Codes;

internal class PacketLoader
{
    private string[] DefaultCoreEntityLayerPacketNames = { "Core.Domain", "Core", "Core.Security", "Core.Persistence" };
    private string[] DefaultEntityLayerPacketNames = { "Domain", "Entity" };
    private string[] DefaultDataLayerPacketNames = { "DataAccess", "Persistence" };
    private string[] DefaultLogiclayerPacketNames = { "Business", "Application" };

    public PacketLoader()
    {

    }
    public IList<Type> GetLoadedPacketDbContexts()
    {
        return GetDbContexts(DefaultDataLayerPacketNames);
    }

    public IList<Type> GetLoadedPacketEntities()
    {
        return GetIEntities(DefaultEntityLayerPacketNames);
    }

    public IList<Type> GetLoadedPacketEntitiesForCore()
    {
        return GetIEntities(DefaultCoreEntityLayerPacketNames);
    }

    private static IList<Assembly> AssembliesLoadVerify(string[] loadPacketNames)
    {
        List<Assembly> verifiedAssembly = new();
        foreach (string packName in loadPacketNames)
        {
            try
            {

                Assembly assembly = Assembly.Load(packName);

                verifiedAssembly.Add(assembly);
            }

            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        return verifiedAssembly;
    }

    public static IList<Type> GetIEntities(string[] loadPacketNames)
    {
        IList<Assembly> assemblies = AssembliesLoadVerify(loadPacketNames);

        List<Type> entities = new();

        foreach (Assembly assembly in assemblies)
        {
            Type[] types = assembly.GetTypes()
                .Where(x => typeof(IEntity).IsAssignableFrom(x) && x.IsClass).ToArray();

            entities.AddRange(types);
        }
        return entities;
    }

    private static IList<Type> GetDbContexts(string[] loadPacketNames)
    {
        IList<Assembly> assemblies = AssembliesLoadVerify(loadPacketNames);

        List<Type> entities = new();

        foreach (Assembly assembly in assemblies)
        {
            Type[] types = assembly.GetTypes()
                .Where(x => typeof(Microsoft.EntityFrameworkCore.DbContext).IsAssignableFrom(x) && x.IsClass).ToArray();

            entities.AddRange(types);
        }
        return entities;
    }
}
