public class Rectangle
{
    private string id;
    private double width;
    private double height;
    private double topLeftHorizontal;
    private double topLeftVertical;

    public Rectangle(string id, double width, double height, double topLeftHorizontal, double topLeftVertical)
    {
        this.Id = id;
        this.Width = width;
        this.Height = height;
        this.TopLeftHorizontal = topLeftHorizontal;
        this.TopLeftVertical = topLeftVertical;
    }

    public string Id
    {
        get { return this.id; }
        set { this.id = value; }
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

    public double TopLeftHorizontal
    {
        get { return this.topLeftHorizontal; }
        set { this.topLeftHorizontal = value; }
    }

    public double TopLeftVertical
    {
        get { return this.topLeftVertical; }
        set { this.topLeftVertical = value; }
    }

    public bool IsIntersection(Rectangle rectangle)
    {
        bool isHorisontalIntersecton = rectangle.TopLeftHorizontal + rectangle.Width >= this.TopLeftHorizontal &&
            rectangle.TopLeftHorizontal <= this.TopLeftHorizontal + this.Width;
        bool isVerticalIntersection = rectangle.TopLeftVertical >= this.TopLeftVertical - this.Height &&
            rectangle.TopLeftVertical - rectangle.Height <= this.TopLeftVertical;

        return isHorisontalIntersecton && isVerticalIntersection;
    }
}