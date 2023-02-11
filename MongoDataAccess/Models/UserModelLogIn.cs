
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;


namespace MongoDataAccess.Models;

public class UserModelLogIn
{
	[BsonId]
	[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]

	public string Id { get; set; }
	public string? username { get; set; }
	public string? password { get; set; }
}


