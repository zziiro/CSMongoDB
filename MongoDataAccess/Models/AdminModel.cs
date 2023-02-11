
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDataAccess.Models;

public class AdminModel
{
	[BsonId]
	[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]

	public string Id { get; set; }
	public string username { get; set; }
	public string password { get; set; }
}

