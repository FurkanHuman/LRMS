using PluralizeService.Core;
using System.Linq;

namespace LRMS.Generator.App.Codes;

public class GenerateEngine
{
    public GenerateEngine()  // maybe all operations in here
    {

    }

    static string RootFeaturePathName = "Features";
    static string RootServicePathName = "Services";
    static string AltServicePathName = "AltServices";

    static string[] FeaturesInDir = { "Commands", "Constants", "Dtos", "Models", "Profiles", "Queries", "Rules" };
    static string[] CommandList = { "Create", "Delete", "Update" };
    static string[] QueryList = { "GetById", "GetList", "GetList0ByDynamic" };


    public static IList<string> Generator(IList<Type> types)
    {
        List<string> paths = new();

        foreach (Type type in types)
        {
            string[] generatedTypePahts = MakeFeatureDirectoriesAndCodes(type);

            string service = MakeAltServicesPathCreator(type);

            paths.AddRange(generatedTypePahts);
            paths.Add(service);
        }

        return paths;
    }

    private static string[] MakeFeatureDirectoriesAndCodes(Type type)
    {
        List<string> paths = new();

        string featureNamepath = $"{RootFeaturePathName}\\{PluralizationProvider.Pluralize(type.Name)}";

        paths.Add(featureNamepath);

        foreach (string feature in FeaturesInDir)
        {
            string fullFeaturesPath = $"{featureNamepath}\\{feature}";

            paths.Add(fullFeaturesPath);

            if (feature == FeaturesInDir[0])
            {
                string[] subCommands = SubCommandPathsGenerator(fullFeaturesPath, type);
                paths.AddRange(subCommands);
            }

            else if (feature == FeaturesInDir[5])
            {
                string[] subQueries = SubQueryPathsGenerator(fullFeaturesPath, type);
                paths.AddRange(subQueries);
            }
        }

        return paths.ToArray();
    }

    private static string[] SubCommandPathsGenerator(string fullFeaturesPath, Type type)
    {
        List<string> subCommandPaths = new();
        string[] commandsPaths = CommandPathCreator(type);

        foreach (string commandPath in commandsPaths)
        {
            string fullCommandsPaths = $"{fullFeaturesPath}\\{commandPath}";
            
           // string stringNamespace = CodeGeneratorHelpers.FindSlashAndReplaceDot(fullCommandsPaths);
            
           // todo

            subCommandPaths.Add(fullCommandsPaths);
        }

        return subCommandPaths.ToArray();
    }

    private static string[] SubQueryPathsGenerator(string fullFeaturesPath, Type type)
    {
        List<string> subQueryPaths = new();

        string[] queriesPaths = QueriesPathCreator(type);

        foreach (string QueryPath in queriesPaths)
        {
            string fullQueriesPaths = $"{fullFeaturesPath}\\{QueryPath}";
            subQueryPaths.Add(fullQueriesPaths);
        }

        return subQueryPaths.ToArray();
    }

    private static string MakeAltServicesPathCreator(Type type)
    {
        return $"{RootServicePathName}\\{AltServicePathName}\\{type.Name}Service";
    }


    private static string[] QueriesPathCreator(Type type)
    {
        List<string> queriesPath = new();

        for (int i = 0; i < QueryList.Length; i++)
        {
            if (QueryList[i].Any(p => p == '0'))
                queriesPath.Add($@"{QueryList[i].Replace("0", type.Name)}");

            else
                queriesPath.Add($"{QueryList[i] + type.Name}");
        }

        return queriesPath.ToArray();
    }

    private static string[] CommandPathCreator(Type type)
    {
        List<string> commandsPaths = new();

        for (int i = 0; i < CommandList.Length; i++)
        {
            commandsPaths.Add($"{CommandList[i] + type.Name}");
        }

        return commandsPaths.ToArray();
    }
}
