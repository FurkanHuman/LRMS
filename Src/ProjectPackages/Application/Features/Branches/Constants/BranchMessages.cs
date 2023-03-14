// this file was created automatically.
namespace Application.Features.Branches.Constants;

public static class BranchMessages
{
    internal static readonly string IsExit = " Is exit";
    internal static readonly string IsNull = "Branch is null";

    internal static string MultiIsExit(IList<string> branchNames)
    {
        return string.Join(", ", branchNames) + IsExit;
    }
}