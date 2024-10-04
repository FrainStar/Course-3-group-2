using Shape;

namespace Figure 
{

    public class Circle : ShapeBase
    {
        public double Area { get; set; }
        public Circle(double area)
        {
            Area = area;
        }
        public override double GetArea()
        {
            return Area;
        }

        public override double GetPerimetr()
        {
            return Math.Sqrt(Area / Math.PI) * 2 * Math.PI;
        }

        public double Getdiametr()
        {
            return Math.Sqrt(Area / Math.PI) * 2;
        }
    }


    public class Rect : ShapeBase
    {
        public double Area { get; set; }
        public Rect(double area)
        {
            Area = area;
        }
        public override double GetArea()
        {
            return Area;
        }

        public override double GetPerimetr()
        {
            return;
        }
    }

    
    public class Triangle : ShapeBase
    {
        public double Area { get; set; }
        public Triangle(double area)
        {
            Area = area;
        }
        public override double GetArea()
        {
            return Area;
        }

        public override double GetPerimetr()
        {
            return;
        }
    }
}