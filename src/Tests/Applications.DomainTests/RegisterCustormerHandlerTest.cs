using System;
using ApiBackend.Domain.Commands.RegisterCustomer;
using ApiBackend.Domain.Core.Interfaces.ServicesAuth0;
using ApiBackend.Helpers.Dto.Configs;
using ApiBackend.Helpers.Exceptions;
using ApiBackend.Infra.Data.Interfaces;
using AutoMapper;
using Bogus;
using Bogus.Extensions.Brazil;
using Moq;
using Tests.Shared;
using Xunit;

namespace Tests.Applications.DomainTests
{
    public class RegisterCustormerHandlerTest
    {
        private readonly Config _config;
        private readonly IDbContextRegisters _dbContext;
        private readonly IMapper _mapper;
        private readonly IRegisterCustomerAuth0 _registerAuth0;
		private readonly Faker _faker;
        private readonly RegisterCustormerRequest _registerCustormerRequest;

        public RegisterCustormerHandlerTest()
        {
            _config = new Config() { Chave = "HR$2pIjHR$2pIj12"};
            _dbContext = new Mock<IDbContextRegisters>().Object;
            _mapper = new Mock<IMapper>().Object;
            _registerAuth0 = new Mock<IRegisterCustomerAuth0>().Object;
			_faker = new Faker();

            _registerCustormerRequest = new RegisterCustormerRequest()
            {
                Id = Guid.NewGuid().ToString(),
                Name =  _faker.Name.FullName(),
                NumberWhats =  _faker.Phone.PhoneNumber("###########"),
                NumberCell =  _faker.Phone.PhoneNumber("###########"),
                Cpf =  _faker.Person.Cpf(true),
                Email =  _faker.Person.Email,
                Password =  _faker.Internet.CustomPassword(8, 10),
                State =  _faker.Address.State(),
                City =  _faker.Address.City(),
                District =  _faker.Address.StreetName(),
                Street =  _faker.Address.StreetName(),
                Number =  _faker.Address.BuildingNumber(),
                Complement =  _faker.Address.FullAddress()
            };
        }

        [Fact]
        public void ValidationRequest_Sucess_Test() 
        {
            RegisterCustormerRequest registerCustormerRequest = _registerCustormerRequest;
            var registerCustormerHandler = new RegisterCustormerHandler(_config,
                                                                        _dbContext,
                                                                        _registerAuth0,
                                                                        _mapper);
            
            var ex = Record.Exception(() => registerCustormerHandler.ValidationRequest(registerCustormerRequest));

            Assert.Null(ex);
        }

        [Fact]
        public void ValidationRequest_Fail_Test()
        {
            RegisterCustormerRequest registerCustormerRequest = _registerCustormerRequest;
            registerCustormerRequest.Cpf = null;
            registerCustormerRequest.Id = null;
            var registerCustormerHandler = new RegisterCustormerHandler(_config,
                                                                        _dbContext,
                                                                        _registerAuth0,
                                                                        _mapper);
            
            Assert.Throws<InvalidException>(() => registerCustormerHandler.ValidationRequest(registerCustormerRequest));
        }
    }
}