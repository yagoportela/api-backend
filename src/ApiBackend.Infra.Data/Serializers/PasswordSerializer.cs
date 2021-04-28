using ApiBackend.Domain.Core.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace ApiBackend.Infra.Data.Serializers
{
    public class PasswordSerializer : ClassSerializerBase<Password>
    {
        protected override Password DeserializeValue(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var bsonReader = context.Reader;
            EnsureBsonTypeEquals(bsonReader, BsonType.String);
            return Password.Parse(bsonReader.ReadString());
        }

        protected override void SerializeValue(BsonSerializationContext context, BsonSerializationArgs args, Password value)
        {
            var bsonWriter = context.Writer;
            bsonWriter.WriteString(value.passwordValue);
        }
    }
}