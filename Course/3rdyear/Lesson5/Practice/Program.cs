using System;
using Shape;
using Figure;

class Program
{
    public static void Main(string[] args)
    {
        ShapeBase circle = new Circle(10);
        Console.WriteLine(circle.GetPerimetr());

    }
}
