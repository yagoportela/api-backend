using System;
using System.Collections.Generic;

namespace ApiBackend.Services.Auth0
{
    public class RegisterCustomerResponse    
    {
        public DateTime created_at { get; set; } 
        public string email { get; set; } 
        public bool email_verified { get; set; } 
        public List<Identity> identities { get; set; } 
        public string name { get; set; } 
        public string nickname { get; set; } 
        public string picture { get; set; } 
        public DateTime updated_at { get; set; } 
        public string user_id { get; set; } 
        public UserMetadata user_metadata { get; set; } 
    }

    public class Identity    
    {
        public string connection { get; set; } 
        public string user_id { get; set; } 
        public string provider { get; set; } 
        public bool isSocial { get; set; } 
    }

    public class UserMetadata    
    {
        public string Parceiro { get; set; } 
    }
}