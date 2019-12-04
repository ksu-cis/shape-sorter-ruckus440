using System;
using System.Collections.Generic;
using System.Linq;

namespace ShapeSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun With Shapes!");
            Console.WriteLine("----------------");

            List<IShape> shapes = new List<IShape>()
            {
                new Circle(4.0),
                new Rectangle(6, 7),
                new Square(5.0),
                new Circle(3.0),
                new Rectangle(2.0, 4.0),
                new Circle(3.0),
                new Square(10)
            };

            foreach (IShape shape in shapes)
            {
                Console.WriteLine($"Area of shape is {shape.Area}");
            }
            Console.WriteLine("-------------");

            IEnumerable<IShape> filterShapes = shapes.Where(shape => shape.Area > 50);
            Console.WriteLine("Shapes with an area > 50");
            foreach (IShape shape in filterShapes)
            {
                Console.WriteLine($"Area of shape is {shape.Area}");
            }
            Console.WriteLine("-------------");

            IEnumerable<Circle> circles;
            //using is keyword
            circles = shapes.OfType<Circle>();

            //Group by
            var groupByArea = shapes.GroupBy(shape => shape.Area % 2 == 0);
            Console.WriteLine(groupByArea.GetType());

            foreach (var group in groupByArea)
            {
                Console.WriteLine(group.Key ? "Evens" : "Odds");
                foreach (var shape in group)
                {
                    Console.WriteLine($"Shape with are {shape.Area}");
                }
            }
            Console.WriteLine("-------------");

            Console.WriteLine("Goup by type");
            var groupByType = shapes.GroupBy(shape => shape.GetType());
            foreach (var group in groupByType)
            {
                Console.WriteLine($"Shapes of type {group.Key.Name}");
                foreach (var shape in group)
                {
                    Console.WriteLine($"Shape with areas {shape.Area}");
                }
            }
            Console.WriteLine("--------------");

            //shapes.GroupBy




            Console.ReadKey();
        }
    }
}
