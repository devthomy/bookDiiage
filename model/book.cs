namespace Classes;

public class Book
{
    public int id { get; set; }
    public string Title { get; set; }
    public string Author { get; set;}
    public DateOnly ReleaseDate { get; set; }
    public int Isbn { get; set; }

    public Book(int id, string title, string author, DateOnly releaseDate, int isbn)
    {
        this.id = id;
        Title = title;
        Author = author;
        ReleaseDate = releaseDate;
        Isbn = isbn;
    }
}

