namespace Core.Utilities.JsonHelper.Abstract
{
    public interface IJsonReader
    {
        string Reader(string? jsonPath, string jsonFile, string jsonKey);
        string Reader(string jsonFile, string jsonKey);
    }
}
