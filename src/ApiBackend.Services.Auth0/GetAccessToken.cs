using System;
using System.Net.Http;
using System.Threading.Tasks;
using ApiBackend.Helpers.Dto.Configs;
using IdentityModel.Client;

namespace ApiBackend.Services.Auth0
{
    public static class GetAccessToken
    {
        public static async Task<string> Token(string address, Auth0Service authServices)
        {
            var authTokenClient = new HttpClient();

            var response = await authTokenClient.RequestTokenAsync(new TokenRequest
                                                                   {
                                                                       Address = address,
                                                                       GrantType = authServices.GrantType,

                                                                       ClientId = authServices.ClientId,
                                                                       ClientSecret = authServices.ClientSecret,

                                                                       Parameters =
                                                                       {
                                                                           {"audience", authServices.Audience},
                                                                       }
                                                                   });
            if (response.IsError) 
                throw new Exception(response.Error);
                
            return response.AccessToken;
        }
    }
}