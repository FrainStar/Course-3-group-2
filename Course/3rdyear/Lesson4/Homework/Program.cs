using System.Linq;
using System;
using System.Globalization;
using System.Security.Cryptography;

public class Student
{
    public int Id { get; set; }
    public string? Name { get; set;  }
}

public class Lessons
{
    public int Id { get; set; }
    public string[]? Lst { get; set; }
}


internal abstract class Program
{
    private static void Main(string[] args)
    {

        List<Student> stud = new List<Student>{new Student{Id=1, Name="John"}, new Student{Id=2, Name="Mary"},  new Student{Id=3, Name="Jane"}};
        List<Lessons> ls = new List<Lessons>{ new Lessons{Id=1, Lst=["Programming on Python", "PI"]}, new Lessons{Id=2, Lst=["Programming on C#", "ABC"]}};
        var joined = stud.Join(ls, s => s.Id, l => l.Id, (l, s) => new { l.Name, s.Lst }).ToList();
        foreach (var j in joined)
        {
            Console.Write($"Student - {j.Name} : ");
            Console.Write("Lessons - ");
            foreach (var l in j.Lst)
            {
                Console.Write($"{l}; ");
            }
            Console.Write("\n");
        }
    }
}