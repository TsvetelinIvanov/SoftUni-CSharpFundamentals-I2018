public interface IGameController
{
    IDatabase Database { get; }

    INinja WinnerNinja { get; }

    void InitialiseGameData(string firstNinjaName);

    void ProcessInput(string inputLine);    
}