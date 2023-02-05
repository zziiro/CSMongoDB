
using System;
using MongoDB.Driver;

namespace BookManagementSystem {

    public class Program
    {

        public static void Main(string[] args)
        {

            PromptUser();
         
        }

        public static void PromptUser()
        {
            string? userPromptOne;

            // get users first action
            Console.WriteLine("A: User | B: Librarian");
            userPromptOne = Console.ReadLine();
            if (userPromptOne == "A")
            {
                userPortion();
            }
            else if (userPromptOne == "B")
            {
                LibrarianPortion();
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
            User user = new User();

       
            Console.WriteLine("Type of Action: ");
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
            Console.WriteLine("IN LIBRARIAN PORTION OF WEB APP");
        }
    }

}
