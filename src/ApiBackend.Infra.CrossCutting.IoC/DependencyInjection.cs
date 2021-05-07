using ApiBackend.Application.Apis.ApiCustomer;
using ApiBackend.Domain.Commands.RegisterCustomer;
using ApiBackend.Application.Interfaces;
using ApiBackend.Domain.Core.Interfaces.ServicesAuth0;
using ApiBackend.Helpers.Dto.Configs;
using ApiBackend.Infra.Data.Cadastro;
using ApiBackend.Infra.Data.Interfaces;
using ApiBackend.Services.Auth0;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using ILogger = Serilog.ILogger;

namespace ApiBackend.Infra.CrossCutting.IoC
{
    public static class DependencyInjection 
    {
        public static void Dependences(IServiceCollection builder)
        {
            AddDependencyDomainCommands (builder);
            AddDependencyDataBase(builder);
            AddDependencyApplication (builder);
            AddDependencyService (builder);
            ConfigureAutoMapper (builder);
            ConfigurationEnvironment (builder); 
        }

        private static void AddDependencyDataBase(IServiceCollection builder)
        {
            DbCustomers dbClientes = Configuration.GetConfiguration()
                .GetSection("dbCustomers")
                .Get<DbCustomers>();  
            
             builder.AddSingleton<IDbContextRegisters>(
                    serviceProvider => new DbContextRegisters(dbClientes.ConnectionString,
                                                              dbClientes.database,
                                                              serviceProvider.GetService<IMediator>(),
                                                              serviceProvider.GetService<ILogger>()));

        }

        private static void AddDependencyService (IServiceCollection builder) 
        {            
            builder.AddTransient<IRegisterCustomerAuth0, RegisterCustomer>();

            builder.AddSingleton((ILogger)new LoggerConfiguration()
                                            .MinimumLevel.Information()
                                            .WriteTo.Console()
                                            .CreateLogger());      
        }

        private static void AddDependencyApplication (IServiceCollection builder) { 
            builder.AddSingleton<IApplicationCustomersHandler, ApplicationCustomerServices>(); 
        }
        private static void AddDependencyDomainCommands (IServiceCollection builder) { 
            builder.AddTransient<IRequestHandler<RegisterCustormerRequest, bool>, RegisterCustormerHandler>(); 
        }

        private static void ConfigurationEnvironment (IServiceCollection builder) {   
                                                                                                       
            builder.AddSingleton<DataConfig> (Configuration.GetConfiguration()
                                                            .GetSection("bdCadastro")
                                                            .Get<DataConfig>());

            builder.AddSingleton<Auth0Service> (Configuration.GetConfiguration()
                                                            .GetSection("Auth0Service")
                                                            .Get<Auth0Service>());

            builder.AddSingleton<Config> (Configuration.GetConfiguration()
                                                        .GetSection("Config")
                                                        .Get<Config>());                                        

        }

        private static void ConfigureAutoMapper (IServiceCollection builder) {

            builder.AddMvc(options =>
            {
                options.RequireHttpsPermanent = true; 
                options.RespectBrowserAcceptHeader = true;
            });

            var mappingConfig = new MapperConfiguration (mc => {
                mc.SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
                mc.DestinationMemberNamingConvention = new PascalCaseNamingConvention();   
                mc.AddProfile (new AutoMapper ());
            });

            IMapper mapper = mappingConfig.CreateMapper ();

            builder.AddSingleton (mapper);
        }
    }
}