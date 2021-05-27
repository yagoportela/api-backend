using System.Linq;
using ApiBackend.Domain.Core.Validations;
using FluentValidation;
using FluentValidation.Results;
using Tests.Domain.Core.Validations;
using Xunit;

namespace Tests.Domain.Core.Validations
{
    public class ValidationCPFTest
    {
        
        [Theory]
        [InlineData("123.456.789-09")]
        [InlineData("822.420.106-62")]
        public void CPF_Is_Valid_Test(string cpf)
        { 
            var person  = new Person { CPF = cpf};

            var validator = new TestExtensionsValidator(x => x.RuleFor(r => r.CPF).IsValidCPF());
            ValidationResult result = validator.Validate(person);

            Assert.True(result.IsValid);            
        }

        [Theory]
        [InlineData("144.442.344-57")]
        [InlineData("543.434.321-76")]
        [InlineData("A822.420.106-62")]
        [InlineData("822.420.106-62a")]
        [InlineData(null)]
        public void CPF_Is_Invalid_Test(string cpf)
        { 
            var person  = new Person { CPF = cpf };

            var validator = new TestExtensionsValidator(x => x.RuleFor(r => r.CPF).IsValidCPF());
            ValidationResult result = validator.Validate(person);

            Assert.False(result.IsValid);            
        }

        [Theory]
        [InlineData("822.420.106-62a")]
        [InlineData(null)]
        public void CPF_Is_Invalid_With_Message_Test(string cpf)
        { 
            var person  = new Person { CPF = cpf };
            const string customMessage = "Custom Message";

            var validator = new TestExtensionsValidator(
                x => x.RuleFor(r => r.CPF)
                      .IsValidCPF()
                      .WithMessage(customMessage));

            ValidationResult result = validator.Validate(person);
            string errorMessage = result.Errors.FirstOrDefault()?.ErrorMessage ?? string.Empty;

            Assert.False(result.IsValid);
            Assert.Equal(customMessage, errorMessage);            
        }
        
    }
}