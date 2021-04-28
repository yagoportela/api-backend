using System;
using System.Threading.Tasks;
using ApiBackend.Domain.Core.Interfaces.ServicesAuth0;
using ApiBackend.Helpers.Dto.Configs;
using ApiBackend.Helpers.Dto.ServicesAuth0;
using ApiBackend.Helpers.Exceptions;
using Flurl;
using Flurl.Http;
using Serilog;

namespace ApiBackend.Services.Auth0
{
    public class RegisterCustomer : IRegisterCustomerAuth0
    {        
        private readonly Auth0Service _authServices;
        private readonly ILogger _logger;

        public RegisterCustomer(Auth0Service authServices,
                                ILogger logger)
        {
            _authServices = authServices;
            _logger = logger;
        }
        
        public async Task<string> Registering(DTOCredential Credentials)
        {
            try{
                _logger.Information("Buscando Token no Auth0", Credentials);

                var authTokenEndpoint = $"{_authServices.Domain}".AppendPathSegment("/oauth/token");
                var token = await GetAccessToken.Token(authTokenEndpoint, _authServices);

                _logger.Information("Busca concluida", token.Substring(0, 10));

                return await RegisteringCustomer(Credentials, token);

            } 
            catch (ConflictException e)
            {
                throw new ConflictException(e.Message);
            }
            catch(Exception ex)
            {   _logger.Error("Erro ao gerar token para as credenciais {@ex}", ex);
                throw new ArgumentException(ex.Message);
            }
        }

        private async Task<string> RegisteringCustomer(DTOCredential Credentials, string token)
        {
            try {
                 _logger.Information("Cadastrando empregador no Auth0");

                var response = await $"{_authServices.Audience}users"
                                        .WithOAuthBearerToken(token)
                                        .PostJsonAsync(new {
                                            connection = "Username-Password-Authentication",    
                                            email = Credentials.Email,
                                            password = Credentials.Password,
                                            email_verified = true
                                        })
                                        .ReceiveJson<RegisterCustomerResponse>();

                _logger.Information("Cadastro efetuado", response);

                return response.user_id;

            }  catch (FlurlHttpException ex)
            {
                _logger.Error("Exception {@ex}", ex);
                var error = await ex.GetResponseJsonAsync();
                var fault = new
                {
                    status = ex.Call.HttpStatus,
                    message = await ex.GetResponseStringAsync()
                };

                _logger.Error("FlurlHttpException details: {@ex}", fault);

                if(error != null && error.statusCode != null && error.statusCode == 409)
                    throw new ConflictException(error.message);

                throw new Exception(fault.message, ex);
            }
            catch (Exception ex)
            {
                _logger.Error("Exception {@ex}", ex);

                throw ex;
            }
        }
    }
}
