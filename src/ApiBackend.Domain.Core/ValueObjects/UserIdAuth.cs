using System;

namespace ApiBackend.Domain.Core.ValueObjects
{
    public class UserIdAuth
    {        
        public readonly string value;

        private UserIdAuth(string userId)
        {
            if(string.IsNullOrEmpty(userId))
                    throw new NullReferenceException(userId);
                    
            value = userId;
        }

        public static implicit operator string(UserIdAuth password) => password.value;
        public static implicit operator UserIdAuth(string value) => new UserIdAuth(value);

    
        public override string ToString() => $"{value}";
    }
}