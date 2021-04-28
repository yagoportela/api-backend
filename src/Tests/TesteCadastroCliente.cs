// using System;
// using ApiBackend.Application.Params;
// using ApiBackend.Lambda.Lambdas;
// using Moq;
// using Serilog;
// using Xunit;

// namespace Tests
// {
//     public class TesteCadastroCliente
//     {        
//         [Fact]
//         public async void Testar()
//         {   
//             var loggerService = new Mock<ILogger>();
//             LambdaCliente lambdaCliente = new LambdaCliente();
            
//             ParamRegisterRequest customer = new ParamRegisterRequest
//             {
//                 id = Guid.NewGuid().ToString(),
//                 name = "Lorem Ipsums14",
//                 numberWhats = "+5511956598459",
//                 numberCell = "+5511956598459",
//                 cpf = "81504988000",
//                 email = "yago.portela14@outlook.com",
//                 password = "Teste@1234",
//                 state = "SP",
//                 city = "Santo André",
//                 district = "Capuava",
//                 street = "malaia",
//                 number = "396",
//                 complement = "S/C"
                
//             };

//             var action = await lambdaCliente.GetTask(customer);
//             var c = action;
//         }

//     }
// }
