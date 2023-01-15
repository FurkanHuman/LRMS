using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRMS.Generator.App.Codes.CreatorCodes;

internal class CsFileOperationConfig
{
    internal string GetDbContext;
    internal byte SelectedRepo;


    public void SetDbContextForType(Type type)
    {
        GetDbContext = type.Name;
    }
}
