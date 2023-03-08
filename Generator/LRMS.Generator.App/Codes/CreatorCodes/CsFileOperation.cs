using LRMS.Generator.App.Codes.CreatorCodes.Configuration;
using LRMS.Generator.App.Codes.CreatorCodes.Feature;
using LRMS.Generator.App.Codes.CreatorCodes.Repository;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LRMS.Generator.App.Codes.CreatorCodes;

internal static class CsFileOperation
{
    static CsFile GetNamespacesPathsAndFileNames(string fileContent)
    {

        SyntaxTree tree = CSharpSyntaxTree.ParseText(fileContent);
        CompilationUnitSyntax root = tree.GetCompilationUnitRoot();

        NamespaceDeclarationSyntax? namespaceNode = root.DescendantNodes().OfType<NamespaceDeclarationSyntax>().FirstOrDefault();
        ClassDeclarationSyntax? classNode = root.DescendantNodes().OfType<ClassDeclarationSyntax>().FirstOrDefault();
        InterfaceDeclarationSyntax? interfaceNode = root.DescendantNodes().OfType<InterfaceDeclarationSyntax>().FirstOrDefault();

        string path = namespaceNode.Name.ToString().Replace('.', '\\') ?? "";

        string fileName = classNode?.Identifier.ValueText ?? interfaceNode?.Identifier.ValueText ?? "";


        return new()
        {
            FileName = fileName,
            Path = path,
            FileContent = fileContent
        };
    }

    public static IList<CsFile> CsFilesEngine(IList<Type> types, CsFileOperationConfig csFileOperationConfig)
    {
        List<CsFile> csFiles = new();

        foreach (Type type in types)
        {
            foreach (string csFileContent in CsFileContentGenerator(type, csFileOperationConfig))
            {
                csFiles.Add(GetNamespacesPathsAndFileNames(csFileContent));
            }
        }

        return csFiles;
    }

    static IList<string> CsFileContentGenerator(Type type, CsFileOperationConfig csFileOperationConfig)
    {
        List<string> fileContents = new();

        CommandCreator commandCreator = new(type);
        ConfigurationCreator configurationCreator = new(type);
        ConstantsCreator constantsCreator = new(type);
        ResponseCreator responseCreator = new(type);
        ProfileCreator profileCreator = new(type);
        QueryCreator queryCreator = new(type);
        RuleCreator ruleCreator = new(type);

        RepositoryCreator repositoryCreator = new(type);

        AltServiceCreator altServiceCreator = new(type);

        fileContents.Add(commandCreator.CreateEntitiyCommand());
        fileContents.Add(commandCreator.CreateEntitiyCommandHandler());
        fileContents.Add(commandCreator.CreateEntitiyCommandValidator());

        fileContents.Add(commandCreator.DeleteEntitiyCommand());
        fileContents.Add(commandCreator.DeleteEntitiyCommandHandler());
        fileContents.Add(commandCreator.DeleteEntitiyCommandValidator());


        fileContents.Add(commandCreator.UpdateEntitiyCommand());
        fileContents.Add(commandCreator.UpdateEntitiyCommandHandler());
        fileContents.Add(commandCreator.UpdateEntitiyCommandValidator());

        fileContents.Add(configurationCreator.CreateEntityConfiguration());

        fileContents.Add(constantsCreator.ConstantsCreate());
        fileContents.Add(constantsCreator.EntityOperationClaimsCreate());


        fileContents.Add(responseCreator.GetByIdResponseCreate());
        fileContents.Add(responseCreator.GetListByResponseCreate());
        fileContents.Add(responseCreator.GetListByDynamicResponseCreate());
        fileContents.Add(responseCreator.CreatedResponseCreate());
        fileContents.Add(responseCreator.DeletedResponseCreate());
        fileContents.Add(responseCreator.UpdatedResponseCreate());


        fileContents.Add(profileCreator.MappingProfileCreator());


        fileContents.Add(queryCreator.GetByIdEntityQuery());
        fileContents.Add(queryCreator.GetByIdEntityQueryHandler());

        fileContents.Add(queryCreator.GetListByEntityQuery());
        fileContents.Add(queryCreator.GetListByEntityQueryHandler());

        fileContents.Add(queryCreator.GetListByEntityDynamicQuery());
        fileContents.Add(queryCreator.GetListByEntityDynamicQueryHandler());


        fileContents.Add(ruleCreator.RuleCreate());


        string IRepository = IRepositorySelector(repositoryCreator, csFileOperationConfig.SelectedRepo);

        fileContents.Add(IRepository);
        fileContents.Add(repositoryCreator.Repository(csFileOperationConfig.GetDbContext));


        fileContents.Add(altServiceCreator.IServiceCreate());
        fileContents.Add(altServiceCreator.ServiceCreate());

        return fileContents;
    }

    private static string IRepositorySelector(RepositoryCreator repositoryCreator,byte selectedRepo)
    {
        return selectedRepo switch
        {
            1 => repositoryCreator.ISyncRepository(),
            2 => repositoryCreator.IAsyncRepository(),
            3 => repositoryCreator.ISyncAndAsyncRepository(),
            _ => repositoryCreator.IEmptyRepository(),
        };
    }
}
