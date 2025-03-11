using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace GeneralLog.Domain.Entities
{
    public class LogEntry
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        public string CedulaCliente { get; set; } = string.Empty;
        public string TipoOperacion { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
    }
}
