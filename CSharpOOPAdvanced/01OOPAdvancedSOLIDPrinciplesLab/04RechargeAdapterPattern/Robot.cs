namespace _04.Recharge
{
    public class Robot : Worker
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

        //RobotAdapter robotAdapter = new RobotAdapter();               

        public void Recharge()
        {
            RobotAdapter robotAdapter = new RobotAdapter(this);
            //robotAdapter.TakeRobot(this);
            robotAdapter.Recharge();
        }        
    }
}