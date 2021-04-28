using System;
using FluentValidation;

namespace Tests.Domain.Core.Validations
{
    public class TestExtensionsValidator : InlineValidator<Person>
    {
        public TestExtensionsValidator()
        { }

        public TestExtensionsValidator(Action<TestExtensionsValidator> action)
        {
            action.Invoke(this);
        }
        
    }
}