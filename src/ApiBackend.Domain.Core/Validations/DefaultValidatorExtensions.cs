using FluentValidation;

namespace ApiBackend.Domain.Core.Validations
{
    public static class DefaultValidatorExtensions
    {
        public static IRuleBuilderOptions<T, string> IsValidCPF<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new ValidationCPF<T, string>());
        }

    }
}