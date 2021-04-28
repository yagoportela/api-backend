using ApiBackend.Domain.Aggregate.Shared;

namespace ApiBackend.Domain.Aggregate.Customer
{
    public class CustomerModelCreateDTO: AddressModelDTO
    {
        public string id {get; set;}
        public string name {get; set;}
        public string userIdAuth {get; set;}
        public string email {get; set;}
        public string numberWhats {get; set;}
        public string numberCell {get; set;}
        public string cpf {get; set;}
        public string password {get; set;}
    }
}