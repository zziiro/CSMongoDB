
using System;

namespace BookManagementSystem {

    public class Program
    {

        public static void Main(string[] args)
        {

            // get the intiailze user decision
            // if a librarian or a normal user 
            string userPromptOne;
            try
            {
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
            }
            catch (Exception e)
            { // if an error or exception occurs
                Console.WriteLine("[ERROR] ", e);
                Console.WriteLine("Invalid Input.. please try again.");
            }


        }

        // for the user protion of the application
        public static void userPortion()
        {
            // init variables
            string userAction;

            // init class methods
            userClass user = new userClass();
            Books book = new Books();


            // get what the user wants to do
            try
            {
                Console.WriteLine("Type of Action: ");
                Console.WriteLine("A: Log In\nB: Become Member\nC: View Catalogue");
                // create variable to hold user action
                userAction = Console.ReadLine();
                if (userAction == "A") // if user wants to log in 
                {
                    // send user to log in screen
                    user.LogIn();
                }else if (userAction == "B") // if user wants to become a member
                {
                    user.becomeMember();
                } else if(userAction == "C") // if user wants to see the catalogue of books
                {
                    book.Catalogue();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("[ERROR] ", e);
                Console.WriteLine("Invalid Input.. please try again.");
            }

        }

        // for the librarian portion of the application
        public static void LibrarianPortion()
        {
            Console.WriteLine("IN LIBRARIAN PORTION OF WEB APP");
        }
    }

}
