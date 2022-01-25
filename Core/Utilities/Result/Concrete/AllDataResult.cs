namespace Core.Utilities.Result.Concrete
{
    public class AllDataResult<T>
    {

        private List<DataResult<T>> _DataResult;
        private bool _Success;

        public AllDataResult()
        {
            _DataResult = new();
            _Success = true;
        }

        public bool IsSuccess()
        {
            return _Success;
        }


        public List<DataResult<T>> GetDataResults()
        {
            return _DataResult;
        }


        public void AddResult(DataResult<T> dataResult)
        {
            _DataResult.Add(dataResult);
            if (!dataResult.Success)
                _Success = false;
        }


        public List<DataResult<T>> GetErrorDataResults()
        {
            List<DataResult<T>> errordataResult = new();
            foreach (DataResult<T> dataResult in _DataResult)
            {
                if (!dataResult.Success)
                    errordataResult.Add(dataResult);
            }
            return errordataResult;
        }

        public List<DataResult<T>> GetSuccessDataResults()
        {
            List<DataResult<T>> successDataResult = new();
            foreach (DataResult<T> dataResult in _DataResult)
            {
                if (dataResult.Success)
                    successDataResult.Add(dataResult);
            }
            return successDataResult;
        }
    }
}
