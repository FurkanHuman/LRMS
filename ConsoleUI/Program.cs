

using ConsoleUI;

Console.WriteLine(Library.Other);
Console.WriteLine(Library.Other.ToString());
Console.WriteLine(Library.Other.GetType());
Console.WriteLine(((byte)Library.Other));

string originalStr = "dog running walk way with owners";

bool find = originalStr.Contains("walK", StringComparison.CurrentCultureIgnoreCase);


if (find)
    Console.WriteLine(find);