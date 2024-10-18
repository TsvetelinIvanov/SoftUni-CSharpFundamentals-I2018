using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private const string CrashReason = "Crashed";
    private const double OvertakingTimeLimit = 2;
    private const double OvertakingTimeDangerLimit = 3;

    private IList<Driver> racingDrivers;
    private Stack<Driver> failedDrivers;
    private TyreFactory tyreFactory;
    private DriverFactory driverFactory;
    private Track track;

    public RaceTower()
    {
        this.racingDrivers = new List<Driver>();
        this.failedDrivers = new Stack<Driver>();
        this.tyreFactory = new TyreFactory();
        this.driverFactory = new DriverFactory();
    }

    public bool IsRaceOver => this.track.CurrentLap == this.track.LapsNumber;

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.track = new Track(lapsNumber, trackLength);
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        //try
        //{
            Driver driver = driverFactory.CreateDriver(commandArgs);
            this.racingDrivers.Add(driver);
        //}
        //catch
        //{
            //throw;
        //}
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string boxReason = commandArgs[0];
        string driverName = commandArgs[1];
        Driver driver = racingDrivers.FirstOrDefault(d => d.Name == driverName);

        switch (boxReason)
        {
            case "Refuel":
                double fuelamount = double.Parse(commandArgs[2]);
                driver.Refuel(fuelamount);
                break;
            case "ChangeTyres":
                List<string> tyreData = commandArgs.Skip(2).ToList();
                Tyre tyre = tyreFactory.CreateTyre(tyreData);
                driver.ChangeTyres(tyre);
                break;
        }
    }   

    public string CompleteLaps(List<string> commandArgs)
    {
        StringBuilder completeLapsBuilder = new StringBuilder();
        int numberOfLaps = int.Parse(commandArgs[0]);
        if (numberOfLaps > this.track.LapsNumber - this.track.CurrentLap)
        {
            try
            {
                throw new ArgumentException(string.Format(OutputMessages.InvalidLaps, this.track.CurrentLap));
            }
            catch (ArgumentException ae)
            {
                return ae.Message;
            }
        }

        for (int lap = 0; lap < numberOfLaps; lap++)
        {
            for (int index = 0; index < this.racingDrivers.Count; index++)
            {
                Driver driver = racingDrivers[index];
                try
                {
                    driver.CompleteLap(this.track.TrackLength);
                }
                catch (ArgumentException ae)
                {
                    driver.Fail(ae.Message);
                    this.failedDrivers.Push(driver);
                    //this.racingDrivers.Remove(driver);
                    this.racingDrivers.RemoveAt(index);
                    index--;
                }
            }

            this.track.CurrentLap++;

            List<Driver> orderedDrivers = this.racingDrivers.OrderByDescending(d => d.TotalTime).ToList();

            for (int i = 0; i < orderedDrivers.Count - 1; i++)
            {
                Driver overtakingDriver = orderedDrivers[i];
                Driver targetDriver = orderedDrivers[i + 1];
                bool isOvertakeHappened = this.TryOvertake(overtakingDriver, targetDriver);
                if (isOvertakeHappened)
                {
                    i++;
                    completeLapsBuilder.AppendLine(string.Format(OutputMessages.OvertakeMessage, overtakingDriver.Name, targetDriver.Name, this.track.CurrentLap));
                }
                else
                {
                    if (!overtakingDriver.IsRacing)
                    {
                        this.failedDrivers.Push(overtakingDriver);
                        this.racingDrivers.Remove(overtakingDriver);
                    }
                }
            }
        }

        if (this.IsRaceOver)
        {
            Driver winnerDriver = racingDrivers.OrderBy(d => d.TotalTime).First();
            completeLapsBuilder.AppendLine(string.Format(OutputMessages.WinnerMessage, winnerDriver.Name, winnerDriver.TotalTime));
        }

        string completedLaps = completeLapsBuilder.ToString().TrimEnd();

        return completedLaps;
    }

    private bool TryOvertake(Driver overtakingDriver, Driver targetDriver)
    {
        double timeDifference = overtakingDriver.TotalTime - targetDriver.TotalTime;

        bool isAggressiveDriver = overtakingDriver is AggressiveDriver && overtakingDriver.Car.Tyre is UltrasoftTyre;
        bool isEnduranceDriver = overtakingDriver is EnduranceDriver && overtakingDriver.Car.Tyre is HardTyre;
        bool isCrashHappened = (isAggressiveDriver && this.track.Weather == Weather.Foggy) 
            || (isEnduranceDriver && this.track.Weather == Weather.Rainy);

        if ((isAggressiveDriver || isEnduranceDriver) && timeDifference <= OvertakingTimeDangerLimit)
        {
            if (isCrashHappened)
            {
                overtakingDriver.Fail(CrashReason);
                
                return false;
            }

            overtakingDriver.TotalTime -= OvertakingTimeDangerLimit;
            targetDriver.TotalTime += OvertakingTimeDangerLimit;

            return true;
        }
        else if (timeDifference <= OvertakingTimeLimit)
        {
            overtakingDriver.TotalTime -= OvertakingTimeLimit;
            targetDriver.TotalTime += OvertakingTimeLimit;

            return true;
        }

        return false;
    }
    
    public string GetLeaderboard()
    {
        StringBuilder leaderboardBuilder = new StringBuilder();
        leaderboardBuilder.AppendLine($"Lap {this.track.CurrentLap}/{this.track.LapsNumber}");

        IEnumerable<Driver> leaderboardDrivers = this.racingDrivers.OrderBy(d => d.TotalTime).Concat(this.failedDrivers);
        int position = 1;
        foreach (Driver driver in leaderboardDrivers)
        {
            leaderboardBuilder.AppendLine($"{position} {driver.ToString()}");
            position++;
        }

        string leaderboard = leaderboardBuilder.ToString().TrimEnd();

        return leaderboard;
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        string weatherString = commandArgs[0];
        bool isValidWeather = Enum.TryParse(typeof(Weather), weatherString, out object weatherObjekt);
        if (!isValidWeather)
        {
            throw new ArgumentException(OutputMessages.InvalidWeatherType);
        }

        Weather weather = (Weather)weatherObjekt;
        track.Weather = weather;
    }
}
