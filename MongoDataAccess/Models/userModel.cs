
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace MongoDataAccess.Models;

public class UserModel
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? username { get; set; }
    public string? password { get; set; }
}

