using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiBackend.Application.Interfaces
{
    public interface IApplicationCustomersHandler
    {
         Task<IActionResult> HandleWithReturn(object command);
    }
}