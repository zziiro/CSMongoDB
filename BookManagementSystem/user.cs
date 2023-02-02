using System;
using MongoDataAccess.Models;
using MongoDataAccess.DataAccess;
namespace BookManagementSystem;

public class User
{
    public async void BecomeMember()
    {
        // variable inits
        string? FirstName;
        string? LastName;
        string? username;
        string? password;

        // UserModel and UserDataAccess Class init
        UserModel user = new UserModel();
        UserDataAccess uda = new UserDataAccess();


        Console.WriteLine("First Name: ");
        FirstName = Console.ReadLine();

        Console.WriteLine("Last Name: ");
        LastName = Console.ReadLine();

        Console.WriteLine("Username: ");
        username = Console.ReadLine();

        Console.WriteLine("Password: ");
        password = Console.ReadLine();

        // send user input to UserModel variables
        FirstName = user.FirstName;
        LastName = user.LastName;
        username = user.username;
        password = user.password;

        // send user info to database
        await uda.CreateUser(user);


    } 
}

