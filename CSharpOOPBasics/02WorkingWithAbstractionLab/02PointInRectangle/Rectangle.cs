public class Rectangle
{
    public Rectangle(int topX, int topY, int bottomX, int bottomY)
    {
        TopLeft = new Point(topX, topY);
        BottomRight = new Point(bottomX, bottomY);
    }

    public Point TopLeft { get; set; }
    public Point BottomRight { get; set; }    

    public bool Contains(Point point)
    {
        bool isInHorizontal = TopLeft.X <= point.X && BottomRight.X >= point.X;
        bool isInVertical = TopLeft.Y <= point.Y && BottomRight.Y >= point.Y;
        bool isInRectangle = isInHorizontal && isInVertical;

        return isInRectangle;
    }
}