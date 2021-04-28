using System.Threading;
using System.Threading.Tasks;
using ApiBackend.Domain.Commands;
using ApiBackend.Domain.Core.Interfaces.ServicesAuth0;
using ApiBackend.Helpers.Exceptions;
using AutoMapper;
using MediatR;
using ApiBackend.Domain.Aggregate.Customer;
using ApiBackend.Helpers.Dto.Configs;
using ApiBackend.Helpers.Dto.ServicesAuth0;
using ApiBackend.Infra.Data.Interfaces;
using System.Linq;

namespace ApiBackend.Domain.Handlers
{
    public class RegisterNewCustormerHandler : IRequestHandler<ClientRegisterCommand, bool>
    {
        private readonly Config _config;
        private readonly IDbContextRegisters _dbContext;
        private readonly IMapper _mapper;
        private readonly IRegisterCustomerAuth0 _registerAuth0;

        public RegisterNewCustormerHandler(Config config,
                                           IDbContextRegisters dbCustomer,
                                           IRegisterCustomerAuth0 registerAuth0,
                                           IMapper mapper)
        {
            _config = config;
            _dbContext = dbCustomer;
            _registerAuth0 = registerAuth0;
            _mapper = mapper;
        }

        public async Task<bool> Handle(ClientRegisterCommand request, CancellationToken cancellationToken)
        {
            ValidationRequest(request);
            var customer = CustomerModelBody(request);
            CheckCustomer(customer.Cpf, customer.Email);
            var userid = await RegisteringAuth0(customer.Name,
                                                customer.Email,
                                                request.Password.ToString());

            customer.addUserAuth(userid);
            await _dbContext.Save(customer);

            return true;
        }

        private static void ValidationRequest(ClientRegisterCommand request)
        {
            if (!request.IsValid())
            {
                var requestError = request.ValidationResult.ToString(" - ");
                throw new InvalidException(requestError);
            }
        }

        private CustomerAggregate CustomerModelBody(ClientRegisterCommand request)
        {
            var filterMap = _mapper.Map<CustomerModelCreateDTO>(request);
            var customer = CustomerAggregate.Create(filterMap, _config.Chave);
            return customer;
        }

        private void CheckCustomer(string cpf, string email)
        {
            var cliente = _dbContext.Customer.FirstOrDefault(c => c.Cpf == cpf || c.Email == email);                                                                        
            if(cliente != null) throw new ConflictException("Cliente já foi cadastrado.");            
        } 

        private async Task<string> RegisteringAuth0(string nome,
                                                    string email,
                                                    string senha)
        {
            DTOCredential Credentials = ModelDtoCredential(nome, email, senha);
            return await _registerAuth0.Registering(Credentials);

            static DTOCredential ModelDtoCredential(string nome, string email, string senha)
            {
                return new DTOCredential()
                {
                    Email = email,
                    UseName = nome,
                    Password = senha.ToString()
                };
            }
        }
    }
}