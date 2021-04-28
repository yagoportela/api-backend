using MongoDB.Driver;
using System;

namespace ApiBackend.Infra.Data.Cadastro
{
    public abstract class MongoDbContextBase
    {
        protected MongoDbContextBase(string connectionString, string database)
        {
            if (connectionString == null || database == null) 
               throw new ArgumentNullException(nameof(connectionString), nameof(database));
            
            MongoClient cliente = new MongoClient(connectionString);
            Database = cliente.GetDatabase(database);
            
        }

        protected IMongoDatabase Database { get; }
    }
}
