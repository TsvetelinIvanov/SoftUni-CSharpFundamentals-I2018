using System.Text;

public class RectangulareFigureDrawer
{
    private double width;
    private double height;

    public RectangularFigureDrawer(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    public double Width
    {
        get { return this.width; }
        set { this.width = value; }
    }

    public double Height
    {
        get { return this.height; }
        set { this.height = value; }
    }

    public string DrawRectangleOrSquare()
    {
        StringBuilder rectangleDrawer = new StringBuilder();
        rectangleDrawer.AppendLine($"|{new string('-', (int)this.Width)}|");
        for (int i = 0; i < (int)this.height - 2; i++)
        {
            rectangleDrawer.AppendLine($"|{new string(' ', (int)this.Width)}|");
        }

        if (height > 1)
        {
            rectangleDrawer.AppendLine($"|{new string('-', (int)this.Width)}|");
        }

        return rectangleDrawer.ToString();
    }
}
