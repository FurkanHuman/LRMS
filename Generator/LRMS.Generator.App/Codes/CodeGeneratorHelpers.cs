﻿using LRMS.Generator.App.Codes.CreatorCodes;

namespace LRMS.Generator.App.Codes;

internal static class CodeGeneratorHelpers
{
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

    public static void WriteCsFiles(IList<CsFile> csFiles, string sPath)
    {
        foreach (CsFile csFile in csFiles)
        {
            string path = $"{sPath}\\{csFile.Path}";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            using FileStream fs = File.Create($"{path}\\{csFile.FileName}.cs");

            using TextWriter tw = new StreamWriter(fs);

            tw.Write(csFile.FileContent);

            tw.Flush(); 
        }
    }
}