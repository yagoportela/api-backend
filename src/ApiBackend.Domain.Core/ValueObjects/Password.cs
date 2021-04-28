using System;
using ApiBackend.Helpers.Senha;

namespace ApiBackend.Domain.Core.ValueObjects
{
    public class Password
    {
        public readonly string value;

        private Password(string password, string key)
        {
            if(string.IsNullOrEmpty(password))
                    throw new NullReferenceException(password);

            if(string.IsNullOrEmpty(key))
                    throw new NullReferenceException(key);
                    
            value = Hash.Encrypt(password, key);
        }

        public static implicit operator string(Password password) => password.value;
        public static implicit operator Password(PasswordCripty value) => new Password(value.Password, value.Key);

        public override string ToString() => $"{value}";
        public string ToString(string key) => Hash.Decrypt(value, key);        
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