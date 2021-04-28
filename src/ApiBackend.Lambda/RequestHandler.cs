// using System;
// using System.Threading.Tasks;
// using ApiBackend.Helpers.Exceptions;
// using ApiBackend.Helpers.RequestStatusCode;
// using Microsoft.AspNetCore.Mvc;
// using Serilog;

// namespace ApiBackend.Lambda
// {
//     public static class RequestHandler
//     {
//         public static async Task<IActionResult> HandleCommand<T>(T request, Func<T, Task<IActionResult>> handler, ILogger log)
//         {
//             try
//             {
//                 log.Debug("Handling HTTP request of type {type}", typeof(T).Name);
//                 await handler(request);
//                 return new OkResult();
//             }
//             catch (ConflictException e)
//             {
//                 log.Error(e, "Error handling the command");
//                 return new ConflictObjectResult(new
//                                                   {
//                                                       error = e.Message, 
//                                                       stackTrace = e.StackTrace
//                                                   });
//             }
//             catch (InvalidException e)
//             {
//                 log.Error(e, "Error handling the command {message}", e);
//                 return new BadRequestObjectResult(new
//                                                   {
//                                                       error = e.Message, 
//                                                       stackTrace = e.StackTrace
//                                                   });
//             }
//             catch (Exception e)
//             {
//                 log.Error(e, "Error handling the command");
//                 return new InternalServerErrorObjectResult(new
//                                                             {
//                                                                 error = e.Message, 
//                                                                 stackTrace = e.StackTrace
//                                                             });
//             }
//         }       
//     }
// }