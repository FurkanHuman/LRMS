using PluralizeService.Core;
using System.Linq;

namespace LRMS.Generator.App.Codes;

public class PathGenerate
{
    public PathGenerate()
    {

    }

    static string RootFeaturePathName = "Features";
    static string RootServicePathName = "Services";
    static string AltServicePathName = "AltServices";

    static string[] FeaturesInDir = { "Commands", "Constants", "Dtos", "Models", "Profiles", "Queries", "Rules" };
    static string[] CommandsInDir = { "Create", "Delete", "ShadowDelete", "Update" };
    static string[] QueriesInDir = { "GetById", "GetList", "GetList0ByDynamic" };


    public static IList<string> PathGenerator(IList<Type> types)
    {
        List<string> paths = new();

        foreach (Type type in types)
        {
            string[] generatedTypePahts = MakeFeatureDirectories(type);

            string service = MakeAltServicesPathCreator(type);

            paths.AddRange(generatedTypePahts);
            paths.Add(service);
        }

        return paths;
    }

    private static string[] MakeFeatureDirectories(Type type)
    {
        List<string> paths = new();

        string featureNamepath = $"{RootFeaturePathName}\\{PluralizationProvider.Pluralize(type.Name)}";

        string[] commandsPaths = CommandPathCreator(type);

        string[] queriesPaths = QueriesPathCreator(type);

        paths.Add(featureNamepath);

        foreach (string feature in FeaturesInDir)
        {
            string fullFeaturesPath = $"{featureNamepath}\\{feature}";

            paths.Add(fullFeaturesPath);

            if (feature == FeaturesInDir[0])
            {
                for (int i = 0; i < commandsPaths.Length; i++)
                {
                    string fullCommandsPaths = $"{fullFeaturesPath}\\{commandsPaths[i]}";
                    paths.Add(fullCommandsPaths);
                }
            }

            if (feature == FeaturesInDir[5])
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

    private static string MakeAltServicesPathCreator(Type type)
    {
        return $"{RootServicePathName}\\{AltServicePathName}\\{type.Name}Service";
    }


    private static string[] QueriesPathCreator(Type type)
    {
        List<string> queriesPath = new();

        for (int i = 0; i < QueriesInDir.Length; i++)
        {
            if (QueriesInDir[i].Any(p => p == '0'))
                queriesPath.Add($@"{QueriesInDir[i].Replace("0", type.Name)}");

            else
                queriesPath.Add($"{QueriesInDir[i] + type.Name}");
        }

        return queriesPath.ToArray();
    }

    private static string[] CommandPathCreator(Type type)
    {
        List<string> commandsPaths = new();

        for (int i = 0; i < CommandsInDir.Length; i++)
        {
            commandsPaths.Add($"{CommandsInDir[i] + type.Name}");
        }

        return commandsPaths.ToArray();
    }

}
