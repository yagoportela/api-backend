using ApiBackend.Domain.Core.Interfaces.Data;
using ApiBackend.Infra.Data.Interfaces;
using MediatR;
using MongoDB.Driver;
using Serilog;
using ApiBackend.Domain.Aggregate.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBackend.Infra.Data.Cadastro
{
    public sealed class DbContextRegisters : MongoDbContextBase, IDbContextRegisters
    {
        private IMongoCollection<CustomerAggregate> _customers;
        private Dictionary<Type, object> _collectionMappings;
        private readonly IMediator _mediator;

        static DbContextRegisters()
        {
            MongoConfigHelperRegisters.Register();
        }

        public DbContextRegisters(string connectionString,
                                  string database,
                                  IMediator mediator,
                                  ILogger logger) : base(connectionString, database)
        {
            logger.Information("Connecting with mongoDB", connectionString);

            _customers = Database.GetCollection<CustomerAggregate>(CollectionsRegisters.CUSTOMERS);

            _collectionMappings = new Dictionary<Type, object>
                                  {
                                      {typeof(CustomerAggregate), _customers}
                                  };
            _mediator = mediator;
        }

        public IQueryable<CustomerAggregate> Customer => _customers.AsQueryable();

        public async Task Save(CustomerAggregate customer)
        {
            await Save(_customers, customer);
        }

        public async Task<T> Load<T>(string id) where T : IAggregate
        {
            var collection = (IMongoCollection<T>)_collectionMappings[typeof(T)];
            return await Load(collection, id);
        }

        private async Task Save<T>(IMongoCollection<T> collection, T model) where T : IAggregate
        {
            if (model == null) 
                throw new ArgumentNullException(nameof(model));
                
            var filter = Builders<T>.Filter.Eq(s => s.Id, model.Id);
            var updateOptions = new ReplaceOptions { IsUpsert = true };
            await collection.ReplaceOneAsync(filter, model, updateOptions);
            await AfterSave(model);
        }

        private async Task<T> Load<T>(IMongoCollection<T> collection, string id) where T : IAggregate
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            var filter = Builders<T>.Filter.Eq(s => s.Id, id);
            var result = await collection.FindAsync(filter);
            return result.SingleOrDefault();
        }

        private async Task DispatchEvents(Queue<INotification> events)
        {
            if (events == null) return;

            while (events.TryDequeue(out var currentEvent))
            {
                await _mediator.Publish(currentEvent);
            }
        }

        private async Task AfterSave(IAggregate model)
        {
            await DispatchEvents(model.GetEvents());
        }
    }
}
