
using MongoDataAccess.Models;
using MongoDB.Driver;

namespace MongoDataAccess.DataAccess;

public class BookDataAccess
{
    private const string ConnectionString = "mongodb://127.0.0.1:27017";
    private const string DatabaseName = "bmsDB";
    private const string bookCollection = "books";

    private IMongoCollection<T> ConnectToMongo<T>(in string collection)
    {
        var client = new MongoClient(ConnectionString);
        var db = client.GetDatabase(DatabaseName);
        return db.GetCollection<T>(collection);

    }

    public Task CreateBook(BookModel book) // creates a new book into db
    {
        // prompt user the BookModel then call this function to send to db
        var booksCollection = ConnectToMongo<BookModel>(bookCollection);
        return booksCollection.InsertOneAsync(book);
    }
}


