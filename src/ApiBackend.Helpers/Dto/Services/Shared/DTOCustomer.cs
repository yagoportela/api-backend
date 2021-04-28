using System;

namespace ApiBackend.Helpers.Dto.Services.Shared
{
    public abstract class DTOCustomer
    {
        public string IdCustumer {get; set;}
        public string Name {get; set;}
        public string UserIdAuth {get; set;}
        public string Email {get; set;}
        public string NumberWhats {get; set;}
        public string NumberCell {get; set;}
        public string Cpf {get; set;}
        public DTOAddress Address {get; set;}
        public string Password {get; set;}
    }
}