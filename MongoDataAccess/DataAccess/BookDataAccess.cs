﻿
using MongoDataAccess.Models;
using MongoDB.Driver;

namespace MongoDataAccess.DataAccess;

public class BookDataAccess
{
    private const string ConnectionString = "";
    private const string DatabaseName = "bmsDB";
    private const string bookCollection = "books";

    private IMongoCollection<T> ConnectToMongo<T>(in string collection)
    {
        var client = new MongoClient(ConnectionString);
        var db = client.GetDatabase(DatabaseName);
        return db.GetCollection<T>(collection);

    }

    public async Task<List<BookModel>> Catalogue()
    {
        var booksCollection = ConnectToMongo<BookModel>(bookCollection);
        var catalogue = await booksCollection.FindAsync(_ => true);
        return catalogue.ToList();
    }

    public void CreateBook(BookModel book) // creates a new book into db
    {
        // prompt user the BookModel then call this function to send to db
        var booksCollection = ConnectToMongo<BookModel>(bookCollection);
        booksCollection.InsertOne(book);
    }

    public void DeleteBook() // delete a document of a book
    {
        string? bookTitle;

        Models.BookModel book = new Models.BookModel();

        Console.WriteLine("Book Title: ");
        bookTitle = Console.ReadLine();

        book.Title = bookTitle;

        var booksCollection = ConnectToMongo<BookModel>(bookCollection);
        booksCollection.DeleteOne(c => c.Title == book.Title);
    }
}


