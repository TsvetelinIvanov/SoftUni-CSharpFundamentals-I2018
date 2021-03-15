using System;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        int[] rectangleCoordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Rectangle rectangle = new Rectangle(rectangleCoordinates[0], rectangleCoordinates[1],
            rectangleCoordinates[2], rectangleCoordinates[3]);
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int[] pointCoordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Point point = new Point(pointCoordinates[0], pointCoordinates[1]);
            bool containsPoint = rectangle.Contains(point);
            Console.WriteLine(containsPoint);
        }
    }
}