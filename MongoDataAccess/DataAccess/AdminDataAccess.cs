using MongoDB.Driver;
using MongoDataAccess.Models;
using MongoDB.Bson;

namespace MongoDataAccess.DataAccess;


public class AdminDataAccess
{
    private const string ConnectionString = "";
    private const string DatabaseName = "";
    private const string AdminCollection = "";

    public IMongoCollection<T> ConnectToMongo<T>(in string collection)
	{
        var client = new MongoClient(ConnectionString);
        var db = client.GetDatabase(DatabaseName);
        return db.GetCollection<T>(AdminCollection);
	}

    public void CreateAdmin(AdminModel admin) // make a new admin
    {
        var adminCollection = ConnectToMongo<AdminModel>(AdminCollection);
        adminCollection.InsertOne(admin);
    }

    public static void AdminLogIn(string username, string password)
    {
        // class init
        UserPortion.User user = new UserPortion.User();
        LibrarianPortion.Librarian lib = new LibrarianPortion.Librarian();
        try
        {
            // connect to mongo
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            var AdminLogInCollection = db.GetCollection<AdminModel>(AdminCollection);

            // make filters
            var adminInfoFilter = Builders<AdminModel>.Filter.Eq(u => u.username, username);

            // apply filters to collection search
            var userInfoFind = AdminLogInCollection.Find(adminInfoFilter).FirstOrDefault().ToBsonDocument();

            // check if they match
            foreach (var i in userInfoFind) // loop through userInfoFind
            {
                if ("username=" + username == i.ToString()) // if username provided matches what is in the 
                {
                    foreach (var k in userInfoFind) // loop through again, because I'm struggling to find a way to get a field
                    {
                        if ("password=" + password == k.ToString())
                        {
                            Console.WriteLine("Logged In!");
                            lib.LibHome();
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
}
