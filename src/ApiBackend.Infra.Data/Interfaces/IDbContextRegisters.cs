using System.Linq;
using System.Threading.Tasks;
using ApiBackend.Domain.Core.Interfaces.Data;
using ApiBackend.Domain.Aggregate.Customer;

namespace ApiBackend.Infra.Data.Interfaces
{
    public interface IDbContextRegisters
    {
        Task<T> Load<T>(string id) where T : IAggregate;
        IQueryable<CustomerAggregate> Customer { get; }
        Task Save(CustomerAggregate customer);
        
    }
}