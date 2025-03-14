using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace GeneralLog.Domain.Entities
{
    public class LogsEntry
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string ClientIdentification { get; set; } = string.Empty;
        public string DocumentType { get; set; } = string.Empty;
        public string OperationType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
    }
}
