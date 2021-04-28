using System.Threading.Tasks;
using ApiBackend.Application.Interfaces;
using ApiBackend.Application.Params;
using ApiBackend.WebApi;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ApiBackend.WebAPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Customers : ControllerBase
    {
        private readonly ILogger _log;
        private readonly IApplicationCustomersHandler _applicationClienteHandler;

        public Customers(ILogger log, IApplicationCustomersHandler applicationClienteHandler)
        {
            _log = log;
            _applicationClienteHandler = applicationClienteHandler;
        }

        [HttpPost]
        public async Task PostCustomer(ParamRegisterRequest customer) =>
            await RequestHandler.HandleCommand(customer, _applicationClienteHandler.HandleWithReturn, _log);
    }
}