public delegate void SoldierDiedHandler(Soldier soldier);

public abstract class Soldier
{
    public event SoldierDiedHandler SoldierDiedHandler;

    public Soldier(string name, int health)
    {
        this.Name = name;
        this.Health = health;
    }

    public string Name { get; private set; }

    public int Health { get; private set; }

    public void TakeAttack()
    {
        this.Health -= 1;
        if (this.Health == 0)
        {
            SoldierDiedHandler?.Invoke(this);
        }
    }

    public abstract void KingUnderAttack();
}
