string originalStr = "dog running walk way with owners";

bool find = originalStr.Contains("walK", StringComparison.CurrentCultureIgnoreCase);

if (find)
    Console.WriteLine(find);