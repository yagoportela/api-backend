using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Validators;

namespace ApiBackend.Domain.Core.Validations
{
    public class ValidationCPF<T, TProperty> : PropertyValidator<T, TProperty>
    {
        public override string Name => "NotNullValidator";
        private static readonly int[] _multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        private static readonly int[] _multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        public override bool IsValid(ValidationContext<T> context, TProperty value)
        {
            if(value == null)
                return false;
                
            if (!Regex.IsMatch(value.ToString(), @"^\d\d\d\.?\d\d\d\.?\d\d\d-?\d\d$"))
                return false;

            var cpf = Regex.Replace(value.ToString(), @"[^\d]", string.Empty);

            if (cpf.Length != 11)
                return false;

            for (var j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    return false;

            var tempCpf = cpf.Substring(0, 9);
            var soma = 0;

            for (var i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * _multiplicador1[i];

            var resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            var digito = resto.ToString();
            tempCpf += digito;
            soma = 0;
            for (var i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * _multiplicador2[i];

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            digito += resto.ToString();

            if (!cpf.EndsWith(digito))
                return false;

            return value != null;
        }

        protected override string GetDefaultMessageTemplate(string errorCode)
            => "A value for {PropertyName} is required";
    }
}