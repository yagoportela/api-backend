using System;
using System.Text.RegularExpressions;

namespace ApiBackend.Domain.Core.ValueObjects
{
    public class Phone
    {
        private Phone(string number) => Number = number;

        public string Number { get; private set; }
        

        public override string ToString()
        {
            return Regex.Replace(Number, @"[^\d]", string.Empty);
        }

        public static Phone Parse(string phone)
        {
            return new Phone(phone);
        }        

        public static implicit operator string(Phone phone) => phone?.Number;
        public static implicit operator Phone(string phone) => new Phone(phone);
    }
}