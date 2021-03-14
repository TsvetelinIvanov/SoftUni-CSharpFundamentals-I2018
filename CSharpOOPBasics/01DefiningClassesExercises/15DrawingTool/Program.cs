using System;

public class Program
{
    static void Main(string[] args)
    {
        string figureType = Console.ReadLine();
        double width = double.Parse(Console.ReadLine());
        double height = 0;
        if (figureType == "Square")
        {
            height = width;
        }
        else if (figureType == "Rectangle")
        {
            height = double.Parse(Console.ReadLine());
        }

        RectangulareFigureDrawer figure = new RectangulareFigureDrawer(width, height);
        string drawedFigure = figure.DrawRectangleOrSquare();
        Console.WriteLine(drawedFigure);
    }
}