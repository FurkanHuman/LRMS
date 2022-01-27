using Core.Utilities.Result.Abstract;

namespace Core.Utilities.Business
{
    static public class BusinessRules
    {
        public static IResult? Run(params IResult[] logics)
        {
            foreach (IResult result in logics)
                if (!result.Success)
                    return result;
            return null;
        }
    }
}