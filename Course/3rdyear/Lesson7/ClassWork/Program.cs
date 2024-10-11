using BookScripts;
using UserScripts;

namespace Lesson7
{
    class Program
    {
        public static void Main()
        {
            User user = new User("admin", "admin", new List<Book>());
            Book book = new Book("War and Peace", "Tolsotoy", 1954);
            BookManage.AddBook(user, book);
            user.Books.ForEach(x => Console.WriteLine(x.Name));
        }
    }
}
