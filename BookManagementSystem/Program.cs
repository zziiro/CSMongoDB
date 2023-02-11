
using System;
using MongoDB.Driver;
using MongoDataAccess.UserPortion;

namespace BookManagementSystem {

    public class Program
    { 
        // class for user class 

        public static void Main(string[] args)
        {

            PromptUser();
         
        }

        public static void PromptUser()
        {
            string? userPromptOne;
            string? adminPW;

            // get users first action
            Console.WriteLine("A: User | B: Librarian");
            userPromptOne = Console.ReadLine();
            if (userPromptOne == "A")
            {
                userPortion();
            }
            else if (userPromptOne == "B")
            {
                Console.WriteLine("Enter Admin Password: ");
                adminPW = Console.ReadLine();
                if (adminPW == "1234") { LibrarianPortion(); }
            }
            else
            {
                Console.WriteLine("[ERROR] That's not an option, please try again..");
                PromptUser();
            }
        }

        // for the user protion of the application
        public static void userPortion()
        {
            // init variables
            string? userAction;

            // class inits
            MongoDataAccess.UserPortion.User user = new MongoDataAccess.UserPortion.User();

            // user action
            Console.WriteLine("Welcome user, please select an option.");
            Console.WriteLine("A: Log In\nB: Become Member\nC: View Catalogue");
            // create variable to hold user action
            userAction = Console.ReadLine();
            if (userAction == "A") // if user wants to log in 
            {
                // send user to log in screen
                user.LogIn();
            }
            else if (userAction == "B") // if user wants to become a member
            {
                user.BecomeMember();
            }
            else if (userAction == "C") // if user wants to see the catalogue of books
            {
                user.SeeCatalogue();
            }
            else
            {
                Console.WriteLine("[ERROR] Invalid Input, please try again..");
                userPortion();
            }

        }

        // for the librarian portion of the application
        public static void LibrarianPortion()
        {
            string? action;
            MongoDataAccess.LibrarianPortion.Librarian lib = new MongoDataAccess.LibrarianPortion.Librarian();
            MongoDataAccess.DataAccess.BookDataAccess BDA = new MongoDataAccess.DataAccess.BookDataAccess();

            // get user action
            Console.WriteLine("Welcome Librarian, please select an option provided below:");
            Console.WriteLine("A: Admin Log In\nB: Create Book\nC: Delete Book");
            action = Console.ReadLine();

            if (action == "A")
            {
                string? adminChoice;

                // if user is an existing admin or wants to make a new admin
                Console.WriteLine("A:Admin Log In\nB:Create A New Admin\n: ");
                adminChoice = Console.ReadLine();
                if (adminChoice == "A") { lib.aLogIn(); }
                else if (adminChoice == "B") { lib.CreateNewAdmin(); }
            }
            else if (action == "B") { lib.CreateBookInstance(); /* create a new book instance */}
            else if (action == "C") { BDA.DeleteBook(); /* delete an entire book instance */}
        }
    }
}
