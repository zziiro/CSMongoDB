
using System;

namespace BookManagementSystem {

    public class Program
    {

        public static void Main(string[] args)
        {

            PromptUser();
         
        }

        // frist user prompt -- made like this for input validation
        public static void PromptUser()
        {
            // get the intiailze user decision
            // if a librarian or a normal user 
            string? userPromptOne;

            // get users first action
            Console.WriteLine("A: User | B: Librarian");
            userPromptOne = Console.ReadLine();

            // if action is User (A)
            if (userPromptOne == "A")
            {
                userPortion();
            }
            // if action is Librarian (B)
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

            // init class methods
            userClass user = new userClass();
            Books book = new Books();


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
                user.becomeMember();
            }
            else if (userAction == "C") // if user wants to see the catalogue of books
            {
                book.Catalogue();
            } else
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
