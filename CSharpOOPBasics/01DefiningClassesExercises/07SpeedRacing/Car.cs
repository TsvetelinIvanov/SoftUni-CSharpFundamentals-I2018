namespace _07SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKm;
        private double traveledDistance;

        public Car(string model, double fuelAmount, double fuelConsumptionPerKm)
        {
            this.model = model;            
            this.fuelConsumptionPerKm = fuelConsumptionPerKm;
            this.FuelAmount = fuelAmount;
            this.TraveledDistance = 0.0;
        }

        public string Model
        {
            get { return this.model; }
        }

        public double FuelAmount
        {
            get { return this.fuelAmount; }
            set { this.fuelAmount = value; }
        }

        public double FuelConsumptionPerKm
        {
            get { return this.fuelConsumptionPerKm; }
        }

        public double TravelledDistance
        {
            get { return this.traveledDistance; }
            set { this.traveledDistance = value; }
        }

        public void Drive(double kilometers)
        {
            double neededFuel = kilometers * this.FuelConsumptionPerKm;

            if (this.FuelAmount < neededFuel)
            {
                System.Console.WriteLine("Insufficient fuel for the drive");
                
                return;
            }

            this.FuelAmount -= neededFuel;
            this.TraveledDistance += kilometers;
        }
    }
}
