using ApiBackend.Domain.Commands;
using ApiBackend.Domain.Core.Validations;
using FluentValidation;

namespace ApiBackend.Domain.Validations
{
    public class CustomerValidation: AbstractValidator<ClientRegisterCommand>
    {
        public CustomerValidation()
        {
            ValidateId();
            ValidateName();
            ValidateNumberCell();
            ValidateNumberWhats();
            ValidateCpf();
            ValidateEmail();
            ValidateState();
            ValidateCity();
            ValidateDistrict();
            ValidateStreet();
            ValidatNumber();
            ValidatePassword();
        }

        protected void ValidateId() 
            => RuleFor(c => c.Id)
                .NotEmpty();

        protected void ValidateName() 
            => RuleFor(c => c.Name)
                .NotEmpty()
                .WithName("nome");

        protected void ValidateNumberCell() 
            => RuleFor(c => c.NumberCell)
                .NotEmpty()
                .WithName("número do celular");

        protected void ValidateNumberWhats() 
            => RuleFor(c => c.NumberCell)
                .NotEmpty()
                .WithName("número do WhatsApp");

        protected void ValidateCpf() 
            => RuleFor(c => c.Cpf)
                .NotEmpty()
                .WithName("CPF")
                .IsValidCPF()
                .WithMessage("CPF inválido");

        protected void ValidateEmail() 
            => RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress()
                .WithName("email");

        protected void ValidateState() 
            => RuleFor(c => c.State)
                .NotEmpty()
                .WithName("estado");

        protected void ValidateCity()
            => RuleFor(c => c.City)
                .NotEmpty()
                .WithName("cidado");

        protected void ValidateDistrict()
            => RuleFor(c => c.District)
                .NotEmpty()
                .WithName("bairro");

        protected void ValidateStreet()
            => RuleFor(c => c.Street)
                .NotEmpty()
                .WithName("rua");

        protected void ValidatNumber()
            => RuleFor(c => c.Number)
                .NotEmpty()
                .WithName("número da casa");

        protected void ValidatePassword()
        {
            int minimumLength = 8;
            RuleFor(c => c.Password)
                .MinimumLength(minimumLength).WithName("Senha")
                .Matches("[A-Z]").WithMessage("Letra maiúscula da senha é obrigatório.")
                .Matches("[a-z]").WithMessage("Letra minúscula da senha é obrigatório.")
                .Matches("[0-9]").WithMessage("número é obrigatório na senha")
                .Matches("[^a-zA-Z0-9]").WithMessage("Caracteres especiais obrigatórios");
        }
    }
}