using FluentValidation.Results;
using MediatR;
using ApiBackend.Domain.Validations;

namespace ApiBackend.Domain.Commands
{
    public class ClientRegisterCommand: IRequest<bool>
    {
        public string Id {get; set;}
        public string Name {get; set;}
        public string UserIdAuth {get; set;}
        public string Email {get; set;}
        public string NumberWhats {get; set;}
        public string NumberCell {get; set;}
        public string Cpf {get; set;}
        public string State {get;set;}
        public string City {get;set;}
        public string District {get;set;}
        public string Street {get;set;}
        public string Number {get;set;}
        public string Complement {get;set;}
        public string Password {get; set;}
        
        public bool IsValid()
        {
            ValidationResult = new CustomerValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public ValidationResult ValidationResult { get; private set; }
    }
}