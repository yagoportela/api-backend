using ApiBackend.Domain.Core.ValueObjects;
using ApiBackend.Infra.Data.Serializers;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;

namespace ApiBackend.Infra.Data.Cadastro
{
    public static class MongoConfigHelperRegisters
    {
        public static void Register()
        {
            var pack = new ConventionPack
                       {
                           new CamelCaseElementNameConvention(),
                           new IgnoreIfDefaultConvention(false),
                           new IgnoreIfNullConvention(true),
                           new EnumRepresentationConvention(BsonType.String)
                       };

            ConventionRegistry.Register("Default conventions", pack, t => true);

            BsonSerializer.RegisterSerializer(typeof(Phone), new PhoneSerializer());
            BsonSerializer.RegisterSerializer(typeof(Password), new PasswordSerializer());
            BsonSerializer.RegisterSerializer(typeof(UserIdAuth), new UserIdAuthSerializer());
        }
    }
}
