using Core.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Result.Concrete
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult():base(default,true) { }
        public SuccessDataResult(string message):base(default,true,message) { }
        public SuccessDataResult(T data) : base(data, true) { }
        public SuccessDataResult(T data,string message):base(data,true,message) { }
    }
}
