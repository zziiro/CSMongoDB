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
			int count = 1; // for trying too many times
			// pompt with option to change password or kick user out for saftey reasons


            // get username
            Console.WriteLine("Username:\n");
            userName = Console.ReadLine();

            // get password
            Console.WriteLine("Password:\n");
            passWord = Console.ReadLine();

			// if forgot password 
            Console.WriteLine("Forgot Password? Type F"); // if user needs to reset their password
            forgotPassword = Console.ReadLine();
            if (forgotPassword == "F" || count < 8)
            {
				// user to reset password
            }

			// check if user exitsts already to allow log in
			// if (username && password in Database.JSON file) -- user exists allow login
			// else -- user does not exist send to become a member function
        }


		// become a member function
		public void becomeMember()
		{
			string userName;
			string passWord;
			string email;
			String[] users = new String[] { "Colin", "Mike", "Cameron"}; // for existing members and added new member to existing users 

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

