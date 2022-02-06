using Core.Utilities.Result.Abstract;
using Microsoft.AspNetCore.Http;

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
