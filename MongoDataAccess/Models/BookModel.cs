
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

// Book model
namespace MongoDataAccess.Models;

public class BookModel
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }
    public string Title { get; set; }
    public string AuthorName { get; set; }
    public string Publisher { get; set; }
    public string AmountInInventory { get; set; }
}

