using System.Threading.Tasks;
using ApiBackend.Helpers.Dto.ServicesAuth0;

namespace ApiBackend.Domain.Core.Interfaces.ServicesAuth0
{
    public interface IRegisterCustomerAuth0
    {         
        Task<string> Registering(DTOCredential Credentials);
    }
}