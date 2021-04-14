public class BlankSpace : GameObject, IBlankSpace
{
    private const char BlankSpaceCharValue = '-';

    private int growthTime;
    private VegetableType vegetableHolder;

    public BlankSpace(IMatrixPosition position, int growthTime, VegetableType vegetableHolder)
        : base(position, BlankSpaceCharValue)
    {
        this.GrowthTime = growthTime;
        this.VegetableHolder = vegetableHolder;
    }

    public int GrowthTime
    {
        get { return this.growthTime; }
        private set { this.growthTime = value; }
    }

    public VegetableType VegetableHolder
    {
        get { return this.vegetableHolder; }
        private set { this.vegetableHolder = value; }
    }

    public void Grow()
    {
        if (this.GrowthTime != -1)
        {
            this.GrowthTime--;
        }
    }
}