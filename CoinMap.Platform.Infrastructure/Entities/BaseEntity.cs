using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CoinMap.Platform.Infrastructure.Entities
{
    public abstract class BaseEntity
    {

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public ObjectId _Id { get; set; }

        public DateTime CreatedDate => this._Id.CreationTime;
    }
}
