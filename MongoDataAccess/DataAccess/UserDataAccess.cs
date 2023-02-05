
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

    public void CreateUser(UserModel user) // adds user to mongodb
    {
        // [WORKS]
        // prompt user with UserModel() class and then call this function from there
        var usersCollection = ConnectToMongo<UserModel>(userCollection);
        usersCollection.InsertOne(user);
        
    }

    public async Task<List<BookModel>> SeeCatalogue() // if user wants to see the entire catalouge
    {
        var booksCollection = ConnectToMongo<BookModel>(bookCollection);
        var catalogue = await booksCollection.FindAsync(_ => true);
        return catalogue.ToList();
        
    }

    

    public void DoesUserExist(string username, string password) // to see if a user exists when trying to log in
    {

        try
        {
            // connect to mongo
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            var usersCollection = db.GetCollection<BsonDocument>("user");

            // make filters
            var usernameFilter = Builders<BsonDocument>.Filter.Eq("username", username);
            var passwordFilter = Builders<BsonDocument>.Filter.Eq("password", password);

            // put filters into variables
            var userDoc = usersCollection.Find(usernameFilter).FirstOrDefault();
            var passwordDoc = usersCollection.Find(passwordFilter).FirstOrDefault();

            // turn filter varibales to strings
            var usernameDocToString = userDoc.ToString();
            var passwordDocToString = passwordDoc.ToString();

            Console.WriteLine(usernameDocToString);
            Console.WriteLine(passwordDocToString);


            // check if they match
            if (usernameDocToString == username)
            {
                if (passwordDocToString == password)
                {
                    Console.WriteLine("Successful Log In!");
                }
                else
                {
                    Console.WriteLine("Password incorrect..");
                    // someone how send back to log in page
                }
            }
            else
            {
                Console.WriteLine("Username incorrect..");
                // someone how send back to log in page
            }
        }
        catch (Exception ex) // catch exceptions
        {
            Console.WriteLine(ex.Message);
        }
        
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


//foreach (var user in users)
//            {
//                if (username == usernameFilter.ToString())
//                {
//                    if (password == passFilter.ToString())
//                    {
//                        Console.WriteLine("Successful Log In");
//                        //userPortion(); find out how to change to file scoped
//                    }
//                }
//                else if (username != usernameFilter.ToString())
//{
//    Console.WriteLine("Username or password incorrect");
//}

//            }