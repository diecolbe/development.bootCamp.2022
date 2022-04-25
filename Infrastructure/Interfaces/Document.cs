using development.Domain.Interfaces;
using MongoDB.Bson;

namespace development.Infrastructure.Interfaces
{
    public class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreationDate => Id.CreationTime;
    }
}
