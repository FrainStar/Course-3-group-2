using ConsoleApp.Models.Implementation;

namespace ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        MultimediaPlayer app = new();
        app.PlayFile(Console.ReadLine());
    }
}