using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.JsonHelper.Abstract
{
    public interface IJsonReader
    {
        string Reader(string? jsonPath, string jsonFile, string jsonKey);
        string Reader(string jsonFile, string jsonKey);
    }
}
