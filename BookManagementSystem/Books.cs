using System;
namespace BookManagementSystem
{
	public class Books
	{

		// general book information 
		public string Title;
		public string Auther;
		public string Genre;
		public int PageCount;
		public int BookID;

		public void Catalogue()
		{
			Console.WriteLine("Inside Catalogue() section");
		}

	}
}

