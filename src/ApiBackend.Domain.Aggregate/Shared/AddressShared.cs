namespace ApiBackend.Domain.Aggregate.Shared
{
    public class AddressShared
    {
        public AddressShared(string state,
                             string city,
                             string district,
                             string street,
                             string number,
                             string complement)
        {
            State = state;
            City = city;
            District = district;
            Street = street;
            Number = number;
            Complement = complement;
        }

        public string State {get;set;}
        public string City {get;set;}
        public string District {get;set;}
        public string Street {get;set;}
        public string Number {get;set;}
        public string Complement {get;set;}

        public static AddressShared Create(AddressModelDTO addressModel)
            => new AddressShared(addressModel.state,
                                 addressModel.city,
                                 addressModel.district,
                                 addressModel.street,
                                 addressModel.number,
                                 addressModel.complement);

        
    }
}