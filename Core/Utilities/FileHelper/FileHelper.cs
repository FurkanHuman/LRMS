using Core.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.FileHelper
{
    public class FileHelper : IFileHelper
    {
        public string FullPath { get; set; }

        public IDataResult<string> AddAsync(IFormFile file)
        {
            var (path, halfPath) = NewPath(file);

            Task task = Task.Run(() =>
            {
                using FileStream filestream = File.Create(path);
                file.CopyTo(filestream);
                filestream.Flush();
            });
            return !task.IsFaulted
                ? new ErrorDataResult<string>(CoreConstants.FileAddTaskFault)
                : new SuccessDataResult<string>(halfPath);
        }

        public IDataResult<string> UpdateAsync(string sourcePath, IFormFile file)
        {
            var (path, halfPath) = NewPath(file);
            Task task = Task.Run(() =>
             {
                 using FileStream stream = File.Create(path);
                 file.CopyTo(stream);
                 stream.Flush();
                 DeleteAsync(sourcePath);
             });
            return !task.IsFaulted
                ? new ErrorDataResult<string>(CoreConstants.FileUpdatedTaskFault)
                : new SuccessDataResult<string>(halfPath);
        }

        public IResult DeleteAsync(string path)
        {
            Task task = Task.Run(() => File.Delete(Environment.CurrentDirectory + path));
            return !task.IsFaulted
                ? new ErrorResult(CoreConstants.FileDeleteTaskFault)
                : new SuccessResult();
        }

        private (string path, string halfPath) NewPath(IFormFile file)
        {
            string fileExtension = Path.GetExtension(file.FileName);

            string creatingUniqueFilename = Guid.NewGuid().ToString("D") + fileExtension;

            string result = FullPath + creatingUniqueFilename;

            if (!Directory.Exists(FullPath))
                Directory.CreateDirectory(FullPath);

            return (result, @"\Images\" + creatingUniqueFilename);
        }
    }
}
