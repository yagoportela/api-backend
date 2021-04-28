using System;
using System.Collections.Generic;
using ApiBackend.Domain.Core.Interfaces.Data;
using ApiBackend.Domain.Core.ValueObjects;
using ApiBackend.Helpers.Senha;
using MediatR;
using ApiBackend.Domain.Aggregate.Shared;

namespace ApiBackend.Domain.Aggregate.Customer
{
    public class CustomerAggregate: IAggregate
    {
        private CustomerAggregate(string id,
                                  string name,
                                  string email,
                                  string numberWhats,
                                  string numberCell,
                                  string cpf,                                  
                                  Password password,
                                  AddressShared address)
        {
            Id = id;
            Name = name;
            Email = email;
            NumberWhats = numberWhats;
            NumberCell = numberCell;
            Cpf = cpf;
            Password = password;
            Address = address;
        }

        public string Id {get; private set;}
        public string Name {get; private set;}
        public UserIdAuth UserIdAuth {get; private set;}
        public string Email {get; private set;}
        public string NumberWhats {get; private set;}
        public Phone NumberCell {get; private set;}
        public string Cpf {get; private set;}
        public AddressShared Address {get; private set;}
        public Password Password {get; private set;}
        private readonly Queue<INotification> _events = new Queue<INotification>();

        public static CustomerAggregate Create(CustomerModelCreateDTO customerModel, string key)
        {
            var address =  AddressShared.Create(customerModel);
            var customer = new CustomerAggregate(customerModel.id,
                                                 customerModel.name,
                                                 customerModel.email,
                                                 customerModel.numberCell,
                                                 customerModel.numberWhats,
                                                 customerModel.cpf,
                                                 new PasswordCripty(customerModel.password, key),
                                                 address);

            return customer;
        }

        public void addUserAuth(string userId)
        {            
            UserIdAuth = userId;
        }

        public Queue<INotification> GetEvents()
        {
            return _events;
        }
    }
}