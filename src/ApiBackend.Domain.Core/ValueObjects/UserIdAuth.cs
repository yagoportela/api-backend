using System;

namespace ApiBackend.Domain.Core.ValueObjects
{
    public class UserIdAuth
    {        
        public readonly string UserId;

        private UserIdAuth(string userId)
        {
            if(string.IsNullOrEmpty(userId))
                    throw new NullReferenceException(userId);
                    
            UserId = userId;
        }
        public static UserIdAuth Parse(string userId)
        {
            return new UserIdAuth(userId);
        }           

        public static implicit operator string(UserIdAuth userAuth0) => userAuth0.UserId;
        public static implicit operator UserIdAuth(string userId) => new UserIdAuth(userId);

    
        public override string ToString() => $"{UserId}";
    }
}