namespace _04.Recharge
{
    public abstract class Worker 
    {
        private string id;
        private int workingHours;

        public Worker(string id)
        {
            this.id = id;
        }

        public string Id
        {
            get { return this.id; }
        }

        public virtual void Work(int hours)
        {
            this.workingHours += hours;
        }        
    }
}