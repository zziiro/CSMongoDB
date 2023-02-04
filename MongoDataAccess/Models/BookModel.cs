
// Book model
namespace MongoDataAccess.Models;

public class BookModel
{
    public string Id { get; set; }  
    public string AuthorFullName { get; set; }
    public string Title { get; set; }
    public string Publisher { get; set; }
    public string AmountInInventory { get; set; }
}

