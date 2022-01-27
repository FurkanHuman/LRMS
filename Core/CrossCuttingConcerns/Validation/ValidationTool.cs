using FluentValidation;
using FluentValidation.Results;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            ValidationResult result = validator.Validate((IValidationContext)entity);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);
        }
    }
}
