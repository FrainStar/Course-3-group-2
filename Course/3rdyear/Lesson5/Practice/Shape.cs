using System;


namespace Shape
{
    public abstract class ShapeBase
    {
        public double Area { get; set; }
        public abstract double GetArea();
        public abstract double GetPerimetr();
    }

}