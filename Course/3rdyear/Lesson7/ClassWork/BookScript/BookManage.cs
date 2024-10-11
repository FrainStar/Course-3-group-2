using UserScripts;

namespace BookScripts
{
    class BookManage : IBookManage
    {
        public static void AddBook(User user, Book book)
        {
            user.Books.Add(book);
            Console.WriteLine("Book added");
        }

        public static void DeleteBook(User user, string nameBook)
        {

            Book b = user.Books.FirstOrDefault(x => x.Name == nameBook) ?? throw new InvalidOperationException();

            user.Books.Remove(b);
            Console.WriteLine("Book delete");
        }

        public static void EditBook(User user, string nameBook)
        {
            Book b = user.Books.FirstOrDefault(x => x.Name == nameBook) ?? throw new InvalidOperationException();
            b.Name = nameBook;
            Console.WriteLine("Book updated");
        }
    }
}