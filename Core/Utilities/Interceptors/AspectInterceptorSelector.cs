using Castle.DynamicProxy;
using Core.Aspects.Autofac.Exception;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using System.Reflection;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            List<ValidationAspectAttribute>? classAttributes = type.GetCustomAttributes<ValidationAspectAttribute>(true).ToList();
            IEnumerable<ValidationAspectAttribute>? methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<ValidationAspectAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            //  classAttributes.Add(new ExceptionLogAspectAttribute(typeof(FileLogger))); // found it TODO: log4Net config file not found error.
            return classAttributes.OrderBy(O => O.Priority).ToArray();
        }
    }
}
