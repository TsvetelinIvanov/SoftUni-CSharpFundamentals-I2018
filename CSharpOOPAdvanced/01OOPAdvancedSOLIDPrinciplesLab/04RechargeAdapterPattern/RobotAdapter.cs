namespace _04.Recharge
{
    public class RobotAdapter : IRechargeable
    {
        private Robot robot;

        public RobotAdapter(Robot robot)
        {
            this.robot = robot;
        }

        //public void TakeRobot(Robot robot)
        //{
        //    this.robot = robot;
        //}

        public void Recharge()
        {
            this.robot.CurrentPower = this.robot.Capacity;
        }

        //public void Recharge(Robot robot)
        //{
        //    this.robot.CurrentPower = this.robot.Capacity;
        //}
    }
}
