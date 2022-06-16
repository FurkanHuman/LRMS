using Castle.DynamicProxy;
using Core.Aspects.Autofac.Exception;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using System.Reflection;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            List<MethodInterceptionBaseAttribute>? classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            IEnumerable<MethodInterceptionBaseAttribute>? methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            //  classAttributes.Add(new ExceptionLogAspectAttribute(typeof(FileLogger))); // found it TODO
            return classAttributes.OrderBy(O => O.Priority).ToArray();
        }
    }
}
