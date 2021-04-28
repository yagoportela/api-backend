using System;
using ApiBackend.Helpers.Senha;

namespace ApiBackend.Domain.Core.ValueObjects
{
    public class Password
    {
        public readonly string passwordValue;

        private Password(string password)
        {
            passwordValue = password;
        }

        private Password(string password, string key)
        {
            if(string.IsNullOrEmpty(password))
                    throw new NullReferenceException(password);

            if(string.IsNullOrEmpty(key))
                    throw new NullReferenceException(key);
                    
            passwordValue = Hash.Encrypt(password, key);
        }

        public static Password Parse(string password)
        {
            return new Password(password);
        }   

        public static implicit operator string(Password password) => password.passwordValue;
        public static implicit operator Password(PasswordCripty value) => new Password(value.Password, value.Key);

        public override string ToString() => $"{passwordValue}";
        public string ToString(string key) => Hash.Decrypt(passwordValue, key);        
    }

    public class PasswordCripty
    {
        public PasswordCripty(string password, string key)
        {
            Password = password;
            Key = key;
        }

        public string Password {get; set;}
        public string Key {get; set;}
    }
}