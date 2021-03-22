using System;
using System.Collections.Generic;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    private List<Mission> missions;

    public Commando(string id, string firstName, string lastName,
        decimal salary, string corps) : base(id, firstName, lastName, salary, corps)
    {
        this.Missions = new List<Mission>();
    }

    public List<Mission> Missions
    {
        get { return this.missions; }
        set { this.missions = value; }
    }

    public override string ToString()
    {
        StringBuilder commandoBuilber = new StringBuilder();
        commandoBuilber.AppendLine(base.ToString());
        commandoBuilber.AppendLine($"Corps: {this.Corps}{Environment.NewLine}Missions:");
        foreach (Mission mission in this.Missions)
        {
            commandoBuilber.AppendLine("  " + mission.ToString());
        }
        string builtCommando = commandoBuilber.ToString().TrimEnd();

        return builtCommando;
    }
}