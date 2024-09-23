using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Rectangle> rectangles = new List<Rectangle>();
        int[] counts = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse).ToArray();
        int rectanglesCount = counts[0];
        int checksCount = counts[1];
        for (int i = 0; i < rectanglesCount; i++)
        {
            Rectangle rectangle = ReadRectangleData();
            rectangles.Add(rectangle);
        }

        for (int i = 0; i < checksCount; i++)
        {
            bool isIntersection = CheckForIntersection(rectangles);
            Console.WriteLine(isIntersection.ToString().ToLower());
        }
    }

    private static Rectangle ReadRectangleData()
    {
        string[] rectangleData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        
        string id = rectangleData[0];
        double width = double.Parse(rectangleData[1]);
        double height = double.Parse(rectangleData[2]);
        double topLeftHorizonal = double.Parse(rectangleData[3]);
        double topLeftVertical = double.Parse(rectangleData[4]);
        
        Rectangle rectangle = new Rectangle(id, width, height, topLeftHorizonal, topLeftVertical);

        return rectangle;
    }

    private static bool CheckForIntersection(List<Rectangle> rectangles)
    {
        string[] rectangleIds = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        
        string firstRectangleId = rectangleIds[0];
        Rectangle firstRectangle = rectangles.Single(r => r.Id == firstRectangleId);
        
        string secondRectangleId = rectangleIds[1];        
        Rectangle secondRectangle = rectangles.Single(r => r.Id == secondRectangleId);
        
        bool isIntersection = firstRectangle.IsIntersection(secondRectangle);

        return isIntersection;
    }    
}
