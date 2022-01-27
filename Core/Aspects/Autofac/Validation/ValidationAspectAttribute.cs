using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using FluentValidation;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspectAttribute : MethodInterceptionAttribute
    {
        private Type _validatorType;
        public ValidationAspectAttribute(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
                throw new System.Exception(AspectMessages.WrongValidationType);

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            IValidator? validator = (IValidator)Activator.CreateInstance(_validatorType);
            Type? entityType = _validatorType.BaseType.GetGenericArguments()[0];
            IEnumerable<object>? entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (IEnumerable<object> entity in entities)
                ValidationTool.Validate(validator, entity);
        }
    }
}
