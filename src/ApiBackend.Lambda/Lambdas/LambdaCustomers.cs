// using System.Threading.Tasks;
// using ApiBackend.Application.Params;
// using ApiBackend.Application.Interfaces;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.DependencyInjection;
// using Serilog;

// namespace ApiBackend.Lambda.Lambdas
// {
//     public class LambdaCliente
//     {        
//         private readonly ILogger _log;
//         private readonly IApplicationCustomersHandler _applicationClienteHandler;

//         public LambdaCliente() : this (ApiServices.ServiceProvider.GetService<ILogger>(),
//                                        ApiServices.ServiceProvider.GetService<IApplicationCustomersHandler>()) { }

//         public LambdaCliente (ILogger log,
//                               IApplicationCustomersHandler applicationClienteHandler) 
//         {
//             _log = log;
//             _applicationClienteHandler= applicationClienteHandler;
//         }

//         public Task<IActionResult> GetTask(ParamRegisterRequest cliente) =>
//             RequestHandler.HandleCommand(cliente, _applicationClienteHandler.HandleWithReturn, _log);
//     }
// }