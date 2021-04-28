// using System;
// using Microsoft.Extensions.DependencyInjection;

// namespace ApiBackend.Lambda
// {
//     public static class Startup
//     {
//         public static ServiceProvider Start(Action<ServiceCollection> configureServices)
//         {
//             var serviceCollection = new ServiceCollection();
//             configureServices(serviceCollection);   
            
//             var serviceProvider = serviceCollection.BuildServiceProvider();

//             return serviceProvider;
//         } 
        
//     }
// }