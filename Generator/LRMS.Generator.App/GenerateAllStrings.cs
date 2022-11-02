using PluralizeService.Core;

namespace LRMS.Generator.App;

public static class GenerateAllStrings
{
    static string[] featuresInDir = { "Commands", "Constants", "Dtos", "Models", "Profiles", "Queries", "Rules" };
    static string[] commandsInDir = { "Create", "Delete","ShadowDelete", "Update" };
    static string[] queriesInDir = { "GetById", "GetList", "GetList0ByDynamic" };


    public static string[] MakeFeatureDirectory(Type type)
    {
        List<string> paths = new();

        string featureNamepath = PluralizationProvider.Pluralize(type.Name);

        string[] commandsPaths = CommandPathCreator(type);

        string[] queriesPaths = QueriesPathCreator(type);

        paths.Add(featureNamepath);

        foreach (string feature in featuresInDir)
        {
            string fullFeaturesPath = $"{featureNamepath}\\{feature}";

            paths.Add(fullFeaturesPath);

            if (feature == featuresInDir[0])
            {
                for (int i = 0; i < commandsPaths.Length; i++)
                {
                    string fullCommandsPaths = $"{fullFeaturesPath}\\{commandsPaths[i]}";
                    paths.Add(fullCommandsPaths);
                }
            }

            if (feature == featuresInDir[5])
            {
                for (int i = 0; i < queriesPaths.Length; i++)
                {
                    string fullQueriesPaths = $"{fullFeaturesPath}\\{queriesPaths[i]}";
                    paths.Add(fullQueriesPaths);
                }
            }
        }

        return paths.ToArray();
    }

    private static string[] QueriesPathCreator(Type type)
    {
        List<string> queriesPath = new();

        for (int i = 0; i < queriesInDir.Length; i++)
        {
            if (queriesInDir[i].Any(p => p == '0'))
                queriesPath.Add($@"{queriesInDir[i].Replace("0", type.Name)}");

            else
                queriesPath.Add($"{queriesInDir[i] + type.Name}");
        }

        return queriesPath.ToArray();
    }

    private static string[] CommandPathCreator(Type type)
    {
        List<string> commandsPaths = new();

        for (int i = 0; i < commandsInDir.Length; i++)
        {
            commandsPaths.Add($"{commandsInDir[i] + type.Name}");
        }

        return commandsPaths.ToArray();
    }

    public static string IRepositoriesCreate(Type type)
    {
        return $@"using Core.Persistence.Repositories;
using {type.Namespace};

namespace Application.Repositories;

public interface I{type.Name}Repository : IAsyncRepository<{type.Name}>, IRepository<{type.Name}>
{{
}}";
    }

    public static string RepositoriesCreate(Type type, string contextName)
    {
        return $@"using Application.Repositories;
using Core.Persistence.Repositories;
using {type.Namespace};
using Persistence.Contexts;

namespace Persistence.Repositories;

public class {type.Name}Repository : EfRepositoryBase<{type.Name}, {contextName}>, I{type.Name}Repository
{{
    public {type.Name}Repository({contextName} context) : base(context)
    {{
    }}
}}";
    }

}
