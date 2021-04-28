using System.Collections.Generic;
using MediatR;

namespace ApiBackend.Domain.Core.Interfaces.Data
{
    public interface IAggregate
    {
        string Id { get; }
        Queue<INotification> GetEvents();
        
    }
}