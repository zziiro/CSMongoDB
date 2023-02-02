
using MongoDataAccess.Models;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;

namespace MongoDataAccess.DataAccess;

public class UserDataAccess
{
    private const string ConnectionString = "mongodb://127.0.0.1:27017";
    private const string DatabaseName = "bmsDB";
    private const string userCollection = "user";

    private IMongoCollection<T> ConnectToMongo<T>(in string collection)
    {
        var client = new MongoClient(ConnectionString);
        var db = client.GetDatabase(DatabaseName);
        return db.GetCollection<T>(collection);

    }

    public Task CreateUser(UserModel user) // this function adds user to mongodb
    {
        // prompt user with usermodel get set data and then call this function from there
        var usersCollection = ConnectToMongo<UserModel>(userCollection);
        return usersCollection.InsertOneAsync(user);
    }

    //public Task LogIn(UserModel user)
    //{
    //    var usersCollection = ConnectToMongo<UserModel>(UserCollection);
        
    //}
}




