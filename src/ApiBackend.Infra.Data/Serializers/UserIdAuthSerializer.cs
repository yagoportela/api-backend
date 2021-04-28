using ApiBackend.Domain.Core.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace ApiBackend.Infra.Data.Serializers
{
    public class UserIdAuthSerializer : ClassSerializerBase<UserIdAuth>
    {
        protected override UserIdAuth DeserializeValue(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var bsonReader = context.Reader;
            EnsureBsonTypeEquals(bsonReader, BsonType.String);
            return UserIdAuth.Parse(bsonReader.ReadString());
        }

        protected override void SerializeValue(BsonSerializationContext context, BsonSerializationArgs args, UserIdAuth value)
        {
            var bsonWriter = context.Writer;
            bsonWriter.WriteString(value.UserId);
        }
    }
}