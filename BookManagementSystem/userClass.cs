using System;

namespace BookManagementSystem
{
	public class userClass
	{
		
		public void LogIn() {

			// init variables
			string userName;
			string passWord;
			string forgotPassword;

			try
			{
				// get username
				Console.WriteLine("Username:\n");
				userName = Console.ReadLine();

				// get password
				Console.WriteLine("Password:\n");
				passWord = Console.ReadLine();

				Console.WriteLine("Forgot Password? Type F"); // if user needs to reset their password
				forgotPassword = Console.ReadLine();
				if(forgotPassword == "F")
				{
					
				} else if (forgotPassword == null)
				{

				}
			} catch (Exception e) // create your own exception to see if user already exists 
			{
				Console.WriteLine("[ERROR] ", e);
				Console.WriteLine("Invalid Input");
			}
		}


		// become a member function
		public void becomeMember()
		{
			string userName;
			string passWord;
			string email;
			string[] users; // for existing members and added new member to existing users 

			try
			{
				// get username
                Console.WriteLine("Username:\n");
                userName = Console.ReadLine();

                // get password
                Console.WriteLine("Password:\n");
                passWord = Console.ReadLine();

				Console.WriteLine("Email:\n");
				email = Console.ReadLine();




            } catch (Exception e) // if there is an error adding the a new user
			{
                Console.WriteLine("[ERROR] ", e);
            }
		}

	}
}

