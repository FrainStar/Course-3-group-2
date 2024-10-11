
using UserScripts;

namespace BookScripts
{
    interface IBookManage
    {
        static abstract void AddBook(User user, Book book);
        static abstract void DeleteBook(User user, string nameBook);
        static abstract void EditBook(User user, string nameBook);
    }
}