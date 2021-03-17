using System;

public class Rectangle : IDrawable
{
    private int width;
    private int height;

    public Rectangle(int width, int height)
    {
        this.Width = width;
        this.Height = height;
    }

    public int Width
    {
        get { return this.width; }
        private set { this.width = value; }
    }

    public int Height
    {
        get { return this.height; }
        private set { this.height = value; }
    }

    public void Draw()
    {
        DrawLine(this.Width, '*', '*');
        for (int i = 1; i < this.Height - 1; i++)
        {
            DrawLine(this.Width, ' ', '*');
        }

        DrawLine(this.Width, '*', '*');
    }

    private void DrawLine(int width, char middle, char border)
    {
        Console.Write(border);
        for (int i = 1; i < width - 1; i++)
        {
            Console.Write(middle);
        }

        Console.WriteLine(border);
    }
}