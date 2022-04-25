using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace development.Domain.Interfaces
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        ObjectId Id { get; set; }
        DateTime CreationDate { get; }
    }
}
