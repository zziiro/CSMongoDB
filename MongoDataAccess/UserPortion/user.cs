﻿using System;
using System;
using MongoDataAccess.Models;
using MongoDataAccess.DataAccess;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Core.Configuration;


namespace MongoDataAccess.UserPortion;

public class User
{

    public void UserHome()
    {
        Console.WriteLine("Back to UserHome()");
    }

    public void LogIn() // user log in
    {
        // variable inits
        string? username;
        string? password;

        // class init
        UserDataAccess UDA = new UserDataAccess();

        Console.WriteLine("Username: ");
        username = Console.ReadLine();

        Console.WriteLine("Password: ");
        password = Console.ReadLine();

        if (username == string.Empty)
        {
            Console.WriteLine("Please enter a username..");
            LogIn();
        }
        else if (password == string.Empty)
        {
            Console.WriteLine("Please enter a password..");
            LogIn();
        }
        else
        {
            UDA.DoesUserExist(username, password);
        }


    }

    public void BecomeMember() // if user wants to become a member
    {
        // variable inits
        string? FirstName;
        string? LastName;
        string? username;
        string? password;

        // UserModel and UserDataAccess Class init
        UserDataAccess UDA = new UserDataAccess();


        Console.WriteLine("First Name: "); // get first name
        FirstName = Console.ReadLine();

        Console.WriteLine("Last Name: "); // get last name
        LastName = Console.ReadLine();

        Console.WriteLine("Username: "); // get username
        username = Console.ReadLine();

        Console.WriteLine("Password: "); // get password
        password = Console.ReadLine();

        UserModel user = new UserModel() // create user model
        {
            FirstName = FirstName,
            LastName = LastName
        };

        UserModelLogIn umLogIn = new UserModelLogIn()
        {
            username = username,
            password = password
        };

        UDA.CreateUser(user);
        UDA.CreateUserLogIn(umLogIn);
            // send user model to mongodb

    }

    public void SeeCatalogue()
    {
        UserDataAccess user = new UserDataAccess();

        user.SeeCatalogue(); // show catalogue
    }
}



