using System;
using ApiBackend.Helpers.Dto.Services.Shared;

namespace ApiBackend.Helpers.Dto.Services
{
    public class DTOClientBD: DTOCustomer
    {
        public DateTime DateRegister { get; set; }
        public DateTime DataUpdate { get; set; }
    }
}