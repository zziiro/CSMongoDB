
using MongoDataAccess.Models;
using MongoDB.Driver;
using MongoDB.Bson;
    
namespace MongoDataAccess.DataAccess;

public class UserDataAccess
{
    private const string ConnectionString = "mongodb://127.0.0.1:27017";
    private const string DatabaseName = "bmsDB";
    private const string userCollection = "user";
    private const string bookCollection = "books";

    private IMongoCollection<T> ConnectToMongo<T>(in string collection) // connect to mongo
    {
        var client = new MongoClient(ConnectionString);
        var db = client.GetDatabase(DatabaseName);
        return db.GetCollection<T>(collection);

    }

    public Task CreateUser(UserModel user) // adds user to mongodb
    {
        // prompt user with UserModel() class and then call this function from there
        var usersCollection = ConnectToMongo<UserModel>(userCollection);
        return usersCollection.InsertOneAsync(user);
    }

    public async Task<List<BookModel>> SeeCatalogue() // if user wants to see the entire catalouge
    {
        var booksCollection = ConnectToMongo<BookModel>(bookCollection);
        var catalogue = await booksCollection.FindAsync(_ => true);
        return catalogue.ToList();
    }

    public void TestConnection() // test the connection to the server
    {
        MongoClient client = new MongoClient(ConnectionString);
        var database = client.GetDatabase(DatabaseName);
        bool isMongoLive = database.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(1000);

        if (isMongoLive)
        {
            Console.WriteLine("MongoDB is Live...");
        }else
        {
            Console.WriteLine("MongoDB is not Live...");
        }
    }

    public async Task DoesUserExist(string username, string password) // to see if a user exists when trying to log in
    {
        // class init
        UserModel _user = new UserModel();

        // connect to mongo and get needed information
        var usersCollection = ConnectToMongo<UserModel>(userCollection);
        var results = await usersCollection.FindAsync(_ => true);   
        var users = results.ToList();

        // filter out the user username and password
        var usernameFilter = Builders<UserModel>.Filter.Eq("username", _user.username);
        var passFilter = Builders<UserModel>.Filter.Eq("password", _user.password);


        foreach(var user in users)
        {
            if(username == usernameFilter.ToString())
            {
                if(password == passFilter.ToString())
                {
                    Console.WriteLine("Successful Log In");
                    //userPortion(); find out how to change to file scoped
                }
            }else if (username != usernameFilter.ToString())
            {
                Console.WriteLine("Username or password incorrect");
            }

        }
    }

}
