// using System;
// using ApiBackend.Infra.CrossCutting.IoC;
// using MediatR;

// namespace ApiBackend.Lambda
// {
//     public class ApiServices
//     {
//         public static IServiceProvider ServiceProvider { get; } =
//             Startup.Start (serviceCollection => {            
//                 serviceCollection.AddMediatR(typeof(IMediator).GetType().Assembly);
//                 DependencyInjection.Dependences(serviceCollection);
//             });
//     }
// }