using ApiBackend.Domain.Core.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace ApiBackend.Infra.Data.Serializers
{
    public class PhoneSerializer : ClassSerializerBase<Phone>
    {
        protected override Phone DeserializeValue(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var bsonReader = context.Reader;
            EnsureBsonTypeEquals(bsonReader, BsonType.String);
            return Phone.Parse(bsonReader.ReadString());
        }

        protected override void SerializeValue(BsonSerializationContext context, BsonSerializationArgs args, Phone value)
        {
            var bsonWriter = context.Writer;
            bsonWriter.WriteString(value.Number);
        }
    }
}