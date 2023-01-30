using System;
using System.IO;

namespace BookManagementSystem
{
	public class userClass : Program
	{
		// create global constant for writing to txt file
		public StreamWriter sw = new StreamWriter("users.txt", true);
		
		public void LogIn() {

            // init variables
            string? userName;
            string? passWord;
            string? forgotPassword;
			bool logIn = true; // too many log in attempt checking
			int logInAttemptCounter = 1; // too many log in attempts 


            // log in validation
			while(logIn)
			{

                // get user username
                Console.WriteLine("Username:\n");
                userName = Console.ReadLine();

                // get user password
                Console.WriteLine("Password:\n");
                passWord = Console.ReadLine();


                // everything checks out, time to end the log in process
                if (userName == string.Empty && passWord == string.Empty)
                {
                    Console.WriteLine("Please enter a username or password..");
                    LogIn(); // send back to beginning
                } else // check user input validation
                {

                    
                    // check if user is failing to log in
                    if (logInAttemptCounter > 6)
                    {
                        Console.WriteLine("Forgot password? Enter 'Y' for yes");
                        Console.WriteLine("Press 'Enter' key for no.");
                        forgotPassword = Console.ReadLine();
                        if (forgotPassword == "Y")
                        {
                            // user to reset password
                        }
                        else
                        {
                            Console.WriteLine("Log in Successful!");
                            userPortion();

                        }
                    }
                    else if (logInAttemptCounter > 8) // if user has had too many attempts
                    {
                        Console.WriteLine("Too many Incorrect log in attempts..");
                        logIn = false; // kill program
                    }

                    // create new user if everything passes through
                    sw.WriteLine(userName, passWord + ", ");
                    sw.Flush(); // force program to move items from buffer to txt file
                    sw.Close(); // close the stream

                    // confirm user log in
                    Console.WriteLine("Logged In!");
                    logIn = false;
                    userPortion();

                    // if (user doesnt exist) 
                    logInAttemptCounter++; // keeps track of amount of log in attempts
                }

            }


			// check if user exitsts already to allow log in
			// if (username && password in user.txt file) -- user exists allow login
			// else -- user does not exist send to become a member function
			// if (user does exist but enters information wrong)
			// count + 1; when count gets to > 8 reset or kick user out for too many attempts

        }


		// become a member function
		public void becomeMember()
		{
			string? userName;
			string? passWord;
			string? email;

            // get username
            Console.WriteLine("Username:\n");
            userName = Console.ReadLine();

            // get password
            Console.WriteLine("Password:\n");
            passWord = Console.ReadLine();

            Console.WriteLine("Email:\n");
            email = Console.ReadLine();

			// user input validation
			if(userName == string.Empty)
			{
				Console.WriteLine("Username not recorded, try again.");
				becomeMember();
			} else if(passWord == string.Empty)
			{
				Console.WriteLine("Password not recorded, try again.");
				becomeMember();
			}
        }

	}
}

