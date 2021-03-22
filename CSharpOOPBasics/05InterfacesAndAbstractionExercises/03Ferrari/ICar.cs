public interface ICar
{
    string Model { get; set; }
    string Driver { get; set; }

    string UseBrakes();
    string PushGasPedal();
}