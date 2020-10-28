using System;

namespace Lab2
{
    abstract class GeometryShape
    {
        public abstract double Area();
    }

    interface IPrint
    {
        public void Print();
    }
    class Rectangle : GeometryShape, IPrint
    {
        public Rectangle(double rec_width, double rec_height)
        {
            width = rec_width;
            heigth = rec_height;
        }

        public override double Area() => width*heigth;

        public void Print()
        {
            Console.WriteLine("Restangle: " + ToString());
        }
        
        public override string ToString() => "widht = " + width.ToString() + " height = "
                                           + heigth.ToString() + " area = " + Area().ToString();
        public double width { get; set; }
        public double heigth { get; set; }
    }

    class Square : Rectangle
    {
        public Square(double sq_width) : base(sq_width, sq_width) { }

        public new void Print()
        {
            Console.WriteLine("Square: " + ToString());
        }

        public override string ToString() => "line = " + width.ToString() + " area = " + Area().ToString();
    }

    class Round : GeometryShape, IPrint
    {
        public Round(double r_radius)
        {
            radius = r_radius;
        }

        public override double Area()
        {
            return Math.PI * radius * radius;
        }

        public void Print()
        {
            Console.WriteLine("Round: " + ToString());
        }
        public override string ToString() => "radius = " + radius.ToString() + " area = " + Area().ToString();
 
        public double radius { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(3, 5.5);

            Square square = new Square(33.3);
            Round round = new Round(4);

            rectangle.Print();
            square.Print();
            round.Print();
        }
    }
}

