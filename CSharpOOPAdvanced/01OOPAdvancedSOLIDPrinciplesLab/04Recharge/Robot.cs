namespace _04.Recharge
{
    public class Robot : Worker, IRechargeable
    {
        private int capacity;
        private int currentPower;

        public Robot(string id, int capacity) : base(id)
        {
            this.capacity = capacity;
        }

        public int Capacity
        {
            get { return this.capacity; }
        }

        public int CurrentPower
        {
            get { return this.currentPower; }
            set { this.currentPower = value; }
        }

        public override void Work(int hours)
        {
            if (hours > this.CurrentPower)
            {
                hours = this.CurrentPower;
            }

            base.Work(hours);
            this.CurrentPower -= hours;
        }

        public void Recharge()
        {
            this.CurrentPower = this.capacity;
        }        
    }
}