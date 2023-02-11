
using MongoDataAccess.Models;
using MongoDB.Driver;
using MongoDB.Bson;
    
namespace MongoDataAccess.DataAccess;

public class UserDataAccess
{
    private const string ConnectionString = "mongodb://127.0.0.1:27017";
    private const string DatabaseName = "bmsDB";
    private const string userCollection = "user";
    private const string userLogInCollection = "userLogIn";
    private const string bookCollection = "books";

    private IMongoCollection<T> ConnectToMongo<T>(in string collection) // connect to mongo
    {
        var client = new MongoClient(ConnectionString);
        var db = client.GetDatabase(DatabaseName);
        return db.GetCollection<T>(collection);
    }

    public void CreateUser(UserModel user) // adds user to mongodb
    {
        // [WORKS]
        // prompt user with UserModel() class and then call this function from there
        var usersCollection = ConnectToMongo<UserModel>(userCollection);
        usersCollection.InsertOne(user);
    }

    public void CreateUserLogIn(UserModelLogIn umLogIn) // saves a users LogIn information
    {
        var UserModelLogInCollection = ConnectToMongo<UserModelLogIn>(userLogInCollection);
        UserModelLogInCollection.InsertOne(umLogIn);
    }

    public void DeleteAccount(UserModel user) // allow the user to delete their account
    {
        var usersCollection = ConnectToMongo<UserModel>(userCollection);
        usersCollection.DeleteOne(u => u.Id == user.Id);
    }

    public void DoesUserExist(string? username, string? password) // [LOG IN METHOD]
    {

        // class init
        UserPortion.User user = new UserPortion.User();
        try
        {
            // connect to mongo
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            var LogInCollection = db.GetCollection<UserModelLogIn>(userLogInCollection);

            // make filters
            var userInfoFilter = Builders<UserModelLogIn>.Filter.Eq(u => u.username, username);

            // apply filters to collection search
            var userInfoFind = LogInCollection.Find(userInfoFilter).FirstOrDefault().ToBsonDocument();

            // check if they match
            foreach (var i in userInfoFind) // loop through userInfoFind
            {
                if ("username=" + username == i.ToString()) // if username provided matches what is in the 
                {
                    foreach(var k in userInfoFind)
                    {
                        if ("password=" + password == k.ToString())
                        {
                            Console.WriteLine("Logged In!");
                            user.UserHome();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Username or password is incorrect..");
            user.LogIn();
        }

    }

    public async Task<List<BookModel>> SeeCatalogue() // if user wants to see the entire catalouge
    {
        var booksCollection = ConnectToMongo<BookModel>(bookCollection);
        var catalogue = await booksCollection.FindAsync(_ => true);
        return catalogue.ToList();
    }

    
    public void TestConnection() // test the connection to the mongo server
    {
        try
        {
            MongoClient client = new MongoClient(ConnectionString);
            var database = client.GetDatabase(DatabaseName);
            bool isMongoLive = database.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(1000);

            if (isMongoLive)
            {
                Console.WriteLine("MongoDB is Live...");
            }
            else
            {
                Console.WriteLine("MongoDB is not Live...");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

   
}