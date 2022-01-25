namespace Core.Utilities.Result.Concrete
{
    public class AllResult
    {
        private List<Result> _Results;
        private bool _Success;

        public AllResult()
        {
            _Results = new();
            _Success = new();
        }

        public bool IsSuccess()
        {
            return _Success;
        }

        public List<Result> GetResults()
        {
            return _Results;
        }

        public void AddResult(Result result)
        {
            _Results.Add(result);
            if (!result.Success)
                _Success = false;
        }

        public List<Result> GetSuccessResults()
        {
            List<Result> successResult = new();
            foreach (Result result in _Results)
            {
                if (result.Success)
                    successResult.Add(result);
            }
            return successResult;
        }

        public List<Result> GetErrorResults()
        {
            List<Result> errorResult = new();
            foreach (Result result in _Results)
            {
                if (!result.Success)
                    errorResult.Add(result);
            }
            return errorResult;
        }
    }
}
