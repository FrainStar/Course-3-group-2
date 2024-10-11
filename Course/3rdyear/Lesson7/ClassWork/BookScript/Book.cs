namespace BookScripts
{

    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int ReleaseYear { get; set; }

        public Book(string name, string author, int releaseYear)
        {
            Name = name; 
            Author = author; 
            ReleaseYear = releaseYear;
        }
    }
}