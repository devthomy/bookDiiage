// See https://aka.ms/new-console-template for more information
using Classes;
using System.Globalization;
Console.WriteLine("Hello, World!");

List<Book> allBooks = new List<Book>
{
    new Book(1, "The Great Gatsby", "F. Scott Fitzgerald", new DateOnly(1925, 4, 10), 978074327),
    new Book(2, "To Kill a Mockingbird", "Harper Lee", new DateOnly(1960, 7, 11), 97804463),
    new Book(3, "1984", "George Orwell", new DateOnly(1949, 6, 8), 978045152),
    new Book(4, "Pride and Prejudice", "Jane Austen", new DateOnly(1813, 1, 28), 978014143),
    new Book(5, "The Catcher in the Rye", "J.D. Salinger", new DateOnly(1951, 7, 16), 97803167),
    new Book(6, "The Hobbit", "J.R.R. Tolkien", new DateOnly(1937, 9, 21), 97805479),
    new Book(7, "Harry Potter and the Philosopher's Stone", "J.K. Rowling", new DateOnly(1997, 6, 26), 9780747),
    new Book(8, "The Da Vinci Code", "Dan Brown", new DateOnly(2003, 3, 18), 9780307)
};

User user1 = new User(1, "John", "Doe", true, new List<Book> { allBooks[0], allBooks[1], allBooks[3], allBooks[5] });
User user2 = new User(2, "Jane", "Smith", false, new List<Book> { allBooks[2], });
User user3 = new User(3, "Alice", "Johnson", true, new List<Book> { allBooks[4], });
User user4 = new User(4, "Bob", "Williams", false, new List<Book> { allBooks[6] });

List<User> users = new List<User> { user1, user2, user3, user4 };

Console.WriteLine("Welcome to the Book Management System");

while (true)
{
    Console.Clear();
    Console.WriteLine("╔═══════════════════════════════════════╗");
    Console.WriteLine("║       Book Management System Menu     ║");
    Console.WriteLine("╠═══════════════════════════════════════╣");
    Console.WriteLine("║ Information:                          ║");
    Console.WriteLine("║ 1. List all books taken by user       ║");
    Console.WriteLine("║ 2. List all books                     ║");
    Console.WriteLine("║ 3. List all users                     ║");
    Console.WriteLine("╠═══════════════════════════════════════╣");
    Console.WriteLine("║ User Management:                      ║");
    Console.WriteLine("║ 4. Add new user                       ║");
    Console.WriteLine("║ 5. Delete user                        ║");
    Console.WriteLine("║ 6. Change user premium status         ║");
    Console.WriteLine("╠═══════════════════════════════════════╣");
    Console.WriteLine("║ Book Management:                      ║");
    Console.WriteLine("║ 7. Add new book                       ║");
    Console.WriteLine("║ 8. Delete book                        ║");
    Console.WriteLine("╠═══════════════════════════════════════╣");
    Console.WriteLine("║ Book Assignment:                      ║");
    Console.WriteLine("║ 9. Assign book to user                ║");
    Console.WriteLine("║ 10. Remove book from user             ║");
    Console.WriteLine("╠═══════════════════════════════════════╣");
    Console.WriteLine("║ 0. Exit                               ║");
    Console.WriteLine("╚═══════════════════════════════════════╝");
    Console.Write("Enter your choice (0-10): ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        // Exit the program
        case "0":
            Console.WriteLine("Goodbye!");
            Console.Clear();
            return;

        // List all books taken by users
        case "1":
            Console.WriteLine("\nList of all books taken by user:");
            foreach (User user in users)
            {
                foreach (Book userBook in user.Books)
                {
                    Console.WriteLine($"{userBook.id} - {userBook.Title} by {userBook.Author} - {userBook.ReleaseDate}");
                }
            }
            break;

        // List all books in the system
        case "2":
            Console.WriteLine("\nList of all books:");
            foreach (Book listBook in allBooks)
            {
                Console.WriteLine($"{listBook.id} - {listBook.Title} {listBook.Author} - {listBook.ReleaseDate}");
            }
            break;

        // List all users in the system
        case "3":
            Console.WriteLine("\nList of all users:");
            foreach (User listUser in users)
            {
                Console.WriteLine($"{listUser.id} - {listUser.Firstname} {listUser.Lastname} - {listUser.isPrenium}");
                foreach (Book userBook in listUser.Books)
                {
                    Console.WriteLine($"    {userBook.id} - {userBook.Title} {userBook.Author} - {userBook.ReleaseDate}");
                }
            }
            break;

        // Add a new user to the system
        case "4":
            Console.WriteLine("Create a new user:");
            Console.WriteLine("Enter the first name:");
            string firstname = Console.ReadLine();
            Console.WriteLine("Enter the last name:");
            string lastname = Console.ReadLine();
            Console.WriteLine("Is premium ?");
            bool isPremium = Convert.ToBoolean(Console.ReadLine());
            User newUser = new User(users.Count + 1, firstname, lastname, isPremium, new List<Book>());
            users.Add(newUser);
            Console.WriteLine("User added.");
            break;

        // Add a new book to the system
        case "5":
            Console.WriteLine("Create a new book:");
            Console.WriteLine("Enter the title:");
            string title = Console.ReadLine();
            Console.WriteLine("Enter the author:");
            string author = Console.ReadLine();
            Console.WriteLine("Enter the release date:");
            DateOnly releaseDate = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine("Enter the ISBN:");
            int isbn = Convert.ToInt32(Console.ReadLine());
            Book newBook = new Book(allBooks.Count + 1, title, author, releaseDate, isbn);
            allBooks.Add(newBook);
            Console.WriteLine("Book added");
            break;

        // Delete a user from the system
        case "6":
            Console.WriteLine("\nList of all users:");
            foreach (User listUser in users)
            {
                Console.WriteLine($"{listUser.id} - {listUser.Firstname} {listUser.Lastname} - {listUser.isPrenium}");
            }
            Console.WriteLine("Enter the id of the user you want to delete:");
            int idUser = Convert.ToInt32(Console.ReadLine());
            users.Remove(users.Find(user => user.id == idUser));
            Console.WriteLine("User deleted");
            break;

        // Delete a book from the system
        case "7":

        // Assign book to user
        case "8":
            Console.WriteLine("Select user you want to assign a book to:");
            foreach (User listUser in users)
            {
                Console.WriteLine($"{listUser.id} - {listUser.Firstname} {listUser.Lastname} - {listUser.isPrenium}");
            }
            int idUserAssign = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Select book you want to assign to user:");
            foreach (Book listBook in allBooks)
            {
                Console.WriteLine($"{listBook.id} - {listBook.Title} - {listBook.Author} - {listBook.ReleaseDate} - ISBN: {listBook.Isbn}");
                if (users.Any(u => u.Books.Any(b => b.id == listBook.id)))
                {
                    Console.WriteLine("  (Already assigned to a user)");
                }
                else
                {
                    Console.WriteLine("  (Available)");
                }
            }
            int idBookAssign = Convert.ToInt32(Console.ReadLine());
            Book bookAssign = allBooks.Find(book => book.id == idBookAssign);
            User userAssign = users.Find(users => users.id == idUserAssign);

            try
            {
                if (users.Any(u => u.Books.Any(b => b.id == bookAssign.id)))
                {
                    Console.WriteLine("This book is already assigned to another user.");
                }
                else if (userAssign.isPrenium && userAssign.Books.Count < 5)
                {
                    userAssign.Books.Add(bookAssign);
                    Console.WriteLine("Book assigned successfully.");
                }
                else if (!userAssign.isPrenium && userAssign.Books.Count < 3)
                {
                    userAssign.Books.Add(bookAssign);
                    Console.WriteLine("Book assigned successfully.");
                }
                else
                {
                    Console.WriteLine(userAssign.isPrenium
                        ? "Premium user has reached the maximum limit of 5 books."
                        : "Regular user has reached the maximum limit of 3 books.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            break;

        // Remove book from user
        case "9":
            Console.WriteLine("Select user you want to remove a book from:");
            foreach (User listUser in users)
            {
                Console.WriteLine($"{listUser.id} - {listUser.Firstname} {listUser.Lastname} - {listUser.isPrenium}");
            }
            int idUserRemove = Convert.ToInt32(Console.ReadLine());
            User userRemove = users.Find(user => user.id == idUserRemove);

            if (userRemove.Books.Count == 0)
            {
                Console.WriteLine("This user has no books assigned.");
            }
            else
            {
                Console.WriteLine("Select book you want to remove from user:");
                foreach (Book book in userRemove.Books)
                {
                    Console.WriteLine($"{book.id} - {book.Title} - {book.Author} - {book.ReleaseDate} - ISBN: {book.Isbn}");
                }
                int idBookRemove = Convert.ToInt32(Console.ReadLine());
                Book bookRemove = userRemove.Books.Find(book => book.id == idBookRemove);

                if (bookRemove != null)
                {
                    userRemove.Books.Remove(bookRemove);
                    Console.WriteLine("Book removed successfully from user.");
                }
                else
                {
                    Console.WriteLine("Book not found in user's list.");
                }
            }
            break;



        case "10":
            Console.WriteLine("Select user you want to change premium status:");
            foreach (User listUser in users)
            {
                Console.WriteLine($"{listUser.id} - {listUser.Firstname} {listUser.Lastname} - {listUser.isPrenium}");
            }
            int userId = Convert.ToInt32(Console.ReadLine());
            User userChange = users.Find(user => user.id == userId);
            if (userChange != null)
            {
                Console.WriteLine("Change user premium status (true/false):");
                bool newPremiumStatus = Convert.ToBoolean(Console.ReadLine());
                userChange.isPrenium = newPremiumStatus;
                Console.WriteLine("User premium status changed successfully.");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
            break;
    }

    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
}
