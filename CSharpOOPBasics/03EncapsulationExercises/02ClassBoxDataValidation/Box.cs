using System;
using System.Text;

public class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double Length
    {
        get { return this.length; }
        private set
        {
            if (value <= 0)
            {                
                throw new ArgumentException("Length cannot be zero or negative.");
            }

            this.length = value;
        }
    }

    public double Width
    {
        get { return this.width; }
        private set
        {
            if (value <= 0)
            {                
                throw new ArgumentException("Width cannot be zero or negative.");
            }

            this.width = value;
        }
    }

    public double Height
    {
        get { return this.height; }
        private set
        {
            if (value <= 0)
            {                
                throw new ArgumentException("Height cannot be zero or negative.");
            }

            this.height = value;
        }
    }

    public double SurfaceArea
    {
        get { return (2 * this.Length * this.Width) + (2 * this.Length * this.Height) + (2 * this.Width * this.Height); }
    }

    public double LateralSurfaceArea
    {
        get { return (2 * this.Length * this.Height) + (2 * this.Width * this.Height); }
    }

    public double Volume
    {
        get { return this.Length * this.Width * this.Height; }
    }

    public override string ToString()
    {
        StringBuilder boxDataBuilder = new StringBuilder();
        boxDataBuilder.AppendLine($"Surface Area - {this.SurfaceArea:f2}");
        boxDataBuilder.AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea:f2}");
        boxDataBuilder.Append($"Volume - {this.Volume:f2}");

        return boxDataBuilder.ToString();
    }
}
