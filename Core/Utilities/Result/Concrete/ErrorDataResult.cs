namespace Core.Utilities.Result.Concrete
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult() : base(default, false) { }
        public ErrorDataResult(string message) : base(default, false, message) { }
        public ErrorDataResult(T data) : base(data, true) { }
        public ErrorDataResult(T data, string message) : base(data, false, message) { }
    }
}
