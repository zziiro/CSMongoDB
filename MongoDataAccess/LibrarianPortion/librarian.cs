
using MongoDataAccess.Models; // bring in models
using MongoDataAccess.DataAccess; // bring in db backend for bookdb
using MongoDB.Driver;
using MongoDB.Bson;
using System;
using MongoDB.Driver.Core.Configuration;

namespace MongoDataAccess.LibrarianPortion;

public class Librarian
{
    private const string ConnectionString = "";
    private const string DatabaseName = "";
    private const string CollectionName = "";


    /// <summary>
    /// For librarian admin log in
    /// </summary>
    public void CreateNewAdmin() // make a new admin
    {
        try {
            // inits
            string? AdminName;
            string? AdminUsername;
            string? AdminPassword;

            Console.WriteLine("Admin Name: ");
            AdminName = Console.ReadLine();

            Console.WriteLine("Admin Username: ");
            AdminUsername = Console.ReadLine();

            Console.WriteLine("Admin Password: ");
            AdminPassword = Console.ReadLine();

            AdminModel adminModel = new AdminModel()
            {
                username = AdminUsername,
                password = AdminPassword
            };

            MongoDataAccess.DataAccess.AdminDataAccess adminDataAccess = new MongoDataAccess.DataAccess.AdminDataAccess();

            adminDataAccess.CreateAdmin(adminModel);
        }catch(Exception ex)
        {
            Console.WriteLine("[ERROR] Please Prvoide Information for Every Field");
        }
        
    }

    public void aLogIn()// for admin login
    {
        string? username;
        string? password;

        Console.WriteLine("Admin Username: ");
        username = Console.ReadLine();

        Console.WriteLine("Admin Password");
        password = Console.ReadLine();

        if (username == string.Empty) { Console.WriteLine("Please Enter a username or password.");  aLogIn(); }

        AdminDataAccess.AdminLogIn(username, password);
    }


    /// <summary>
    /// for admin method powers
    /// </summary>
    public void CreateBookInstance() { // create a new instance of a book in db

        // create new book function

        BookDataAccess BDA = new BookDataAccess();

        try
        {
            string? title;
            string? author;
            string? publisher;
            string? amountInInventory;

            Console.WriteLine("Book Title: ");
            title = Console.ReadLine();

            Console.WriteLine("Author name: ");
            author = Console.ReadLine();

            Console.WriteLine("Publisher name: ");
            publisher = Console.ReadLine();

            Console.WriteLine("Number of Books: ");
            amountInInventory = Console.ReadLine();

            BookModel book = new BookModel()
            {
                Title = title,
                AuthorName = author,
                Publisher = publisher,
                AmountInInventory = amountInInventory,
            };

            BDA.CreateBook(book);
        }catch (Exception ex)
        {
            Console.WriteLine("[ERROR] Please Prvoide Information for Every Field");
        }
    }


    public void LibHome()
    {
        Console.WriteLine("Librarian Home Page");
    }
}

