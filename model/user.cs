namespace Classes;

public class User
{
    public int id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public Boolean isPrenium { get; set; }
    public List<Book> Books { get; set; }

    public User(int id, string firstname, string lastname, Boolean isPrenium, List<Book> books)
    {
        this.id = id;
        this.Firstname = firstname;
        this.Lastname = lastname;
        this.isPrenium = isPrenium;
        this.Books = books;

    }
}