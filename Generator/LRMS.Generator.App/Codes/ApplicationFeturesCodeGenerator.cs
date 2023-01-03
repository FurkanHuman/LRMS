using Microsoft.AspNetCore.Mvc;

namespace LRMS.Generator.App.Codes;

internal class ApplicationFeturesCodeGenerator
{
    // Zero "0" is entity name


    static string[] CommandList = { "Create", "Delete", "Update" };
    static string[] ConstantList = { "Messages" };
    static string[] DtoList = { "Dto", "ListDto", "Created0Dto", "Deleted0Dto", "Updated0Dto" };
    static string[] ModelList = { "ListModel" };
    static string[] ProfileList = { "Profiles" };
    static string[] QueryList = { "GetById", "GetList", "GetList0ByDynamic" };
    static string[] RuleList = { "Rules" };

    static List<string[]> FileNames = new() { CommandList, ConstantList, DtoList, ModelList, ProfileList, QueryList, RuleList };

    private static string[] MakeNames(Type type)
    {
        return null;
    }
}
