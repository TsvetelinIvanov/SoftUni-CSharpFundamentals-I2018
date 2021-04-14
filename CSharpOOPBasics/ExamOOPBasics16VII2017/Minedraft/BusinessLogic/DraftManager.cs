using System;
using System.Collections.Generic;
using System.Linq;

public class DraftManager
{
    private string mode;
    private double totalStoredEnergy;
    private double totalMinedOre;
    private HarvesterFactory harvesterFactory;
    private ProviderFactory providerFactory;
    private List<Harvester> harvesters;
    private List<Provider> providers;   

    public DraftManager()
    {
        this.mode = "Full";
        this.totalStoredEnergy = 0;
        this.totalMinedOre = 0;
        this.harvesterFactory = new HarvesterFactory();
        this.providerFactory = new ProviderFactory();
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();       
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            Harvester harvester = harvesterFactory.CreateHarvester(arguments);
            this.harvesters.Add(harvester);

            return $"Successfully registered {harvester.Type} Harvester - {harvester.Id}";
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            Provider provider = providerFactory.CreateProvider(arguments);
            this.providers.Add(provider);

            return $"Successfully registered {provider.Type} Provider - {provider.Id}";
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }
    }

    public string Day()
    {
        double dayEnergyOutput = providers.Sum(p => p.EnergyOutput);
        this.totalStoredEnergy += dayEnergyOutput;

        double dayEnergyRequirement = 0;
        double dayOreOutput = 0;
        if (this.mode == "Full")
        {
            dayEnergyRequirement = harvesters.Sum(h => h.EnergyRequirement);
            dayOreOutput = harvesters.Sum(h => h.OreOutput);
        }
        else if (this.mode == "Half")
        {
            dayEnergyRequirement = harvesters.Sum(h => h.EnergyRequirement) * 0.6;
            dayOreOutput = harvesters.Sum(h => h.OreOutput) * 0.5;
        }
        //else if (this.mode == "Energy")
        //{
        //    dayEnergyRequirement = 0;
        //    dayOreOutput = 0;
        //}
        //else
        //{
        //    throw new ArgumentException("The mode command is incorrect!");
        //}

        if (this.totalStoredEnergy >= dayEnergyRequirement)
        {
            this.totalStoredEnergy -= dayEnergyRequirement;
            this.totalMinedOre += dayOreOutput;
        }
        else
        {
            dayOreOutput = 0;
        }

        return $"A day has passed.{Environment.NewLine}" +
            $"Energy Provided: {dayEnergyOutput}{Environment.NewLine}" +
            $"Plumbus Ore Mined: {dayOreOutput}";
    }

    public string Mode(List<string> arguments)
    {
        this.mode = arguments[0];

        return $"Successfully changed working mode to {this.mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];
        Unit unit = (Unit)harvesters.FirstOrDefault(h => h.Id == id) ?? providers.FirstOrDefault(p => p.Id == id);
        if (unit != null)
        {
            return unit.ToString();
        }
        else
        {
            return $"No element found with id - {id}";
        }
    }

    public string ShutDown()
    {
        return $"System Shutdown{Environment.NewLine}" +
            $"Total Energy Stored: {this.totalStoredEnergy}{Environment.NewLine}" +
            $"Total Mined Plumbus Ore: {this.totalMinedOre}";
    }
}