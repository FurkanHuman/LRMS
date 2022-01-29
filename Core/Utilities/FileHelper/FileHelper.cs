using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.FileHelper
{
    public class FileHelper:IFileHelper
    {
        public string FullPath { get; set; }

        public IDataResult<string> AddAsync(IFormFile file)
        {
            var (path, halfPath) = NewPath(file);

            Task.Run(() =>
            {
                using FileStream filestream = File.Create(path);
                file.CopyTo(filestream);
                filestream.Flush();
            });
            return new SuccessDataResult<string>(halfPath);
        }

        public IDataResult<string> UpdateAsync(string sourcePath, IFormFile file)
        {
            var (path, halfPath) = NewPath(file);
            Task.Run(() =>
            {
                using FileStream stream = File.Create(path);
                file.CopyTo(stream);
                stream.Flush();
                DeleteAsync(sourcePath);
            });
            return new SuccessDataResult<string>(halfPath);
        }

        public IResult DeleteAsync(string path)
        {
            Task.Run(() => File.Delete(Environment.CurrentDirectory + path));
            return new SuccessResult();
        }

        private (string path, string halfPath) NewPath(IFormFile file)
        {
            string fileExtension = Path.GetExtension(file.FileName);

            string creatingUniqueFilename = Guid.NewGuid().ToString("B") + fileExtension;

            string result = FullPath + creatingUniqueFilename;

            if (!Directory.Exists(FullPath))
                Directory.CreateDirectory(FullPath);

            return (result, @"\Images\" + creatingUniqueFilename);
        }
    }
}
