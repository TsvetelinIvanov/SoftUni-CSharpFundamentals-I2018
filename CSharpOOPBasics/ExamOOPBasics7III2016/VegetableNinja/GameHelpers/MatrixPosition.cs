public class MatrixPosition : IMatrixPosition
{
    private int positionX;
    private int positionY;

    public MatrixPosition(int positionX, int positionY)
    {
        this.PositionX = positionX;
        this.PositionY = positionY;
    }

    public int PositionX
    {
        get { return this.positionX; }
        protected set
        {
            if (value < 0)
            {
                throw new NotInMatrixException("The position is not in Matrix!");
            }

            this.positionX = value;
        }
    }

    public int PositionY
    {
        get { return this.positionY; }
        protected set
        {
            if (value < 0)
            {
                throw new NotInMatrixException("The position is not in Matrix!");
            }

            this.positionY = value;
        }
    }

    public bool Equals(IMatrixPosition otherPosition)
    {
        return this.PositionX == otherPosition.PositionX && this.PositionY == otherPosition.PositionY;
    }
}