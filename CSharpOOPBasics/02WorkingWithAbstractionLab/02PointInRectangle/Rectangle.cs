public class Rectangle
{
    public Rectangle(int topX, int topY, int bottomX, int bottomY)
    {
        this.TopLeft = new Point(topX, topY);
        this.BottomRight = new Point(bottomX, bottomY);
    }

    public Point TopLeft { get; set; }
    
    public Point BottomRight { get; set; }    

    public bool Contains(Point point)
    {
        bool isInHorizontal = this.TopLeft.X <= point.X && this.BottomRight.X >= point.X;
        bool isInVertical = this.TopLeft.Y <= point.Y && this.BottomRight.Y >= point.Y;
        bool isInRectangle = isInHorizontal && isInVertical;

        return isInRectangle;
    }
}
