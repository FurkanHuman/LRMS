using Core.Utilities.Result.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.FileHelper
{
    public interface IFileHelper
    {
        public string FullPath { get; set; }
        IDataResult<string> AddAsync(IFormFile file);
        IDataResult<string> UpdateAsync(string sourcePath, IFormFile file);
        IResult DeleteAsync(string path);
    }
}
