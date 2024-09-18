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

        RectangularFigureDrawer figureDrawer = new RectangularFigureDrawer(width, height);
        string drawedFigure = figureDrawer.DrawRectangleOrSquare();
        Console.WriteLine(drawedFigure);
    }
}
