
using BookScripts;

namespace UserScripts
{
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<Book> Books { get; set; }

        public User(string name, string password, List<Book> books)
        {
            Name = name;
            Password = password;
            Books = books;
        }

    }
}