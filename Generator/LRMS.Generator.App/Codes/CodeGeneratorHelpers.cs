namespace LRMS.Generator.App.Codes
{
    internal static class CodeGeneratorHelpers
    {

        public static string FindSlashAndReplaceDot(string slashesString)
            => slashesString.Replace('\\', '.');

        public static string[] FindZeroAndReplaceEntity(string[] stringList, Type type)
        {
            List<string> names = new();

            foreach (string str in stringList)
            {
                string NewName = FindZeroAndReplaceEntity(str, type);
                names.Add(NewName);
            }

            return names.ToArray();
        }

        public static string FindZeroAndReplaceEntity(string name, Type type)
        {
            if (name.Any(s => s == '0'))
                return $@"{name.Replace("0", type.Name)}";

            return $@"{name + type.Name}";
        }
    }
}