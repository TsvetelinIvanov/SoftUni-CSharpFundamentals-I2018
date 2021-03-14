using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Trainer> trainers = GetTrainers();
        TreatElementsEffect(trainers);
        foreach (Trainer trainer in trainers.OrderByDescending(t => t.BadgesCount))
        {
            Console.WriteLine(trainer.Name + " " + trainer.BadgesCount + " " + trainer.Pokemons.Count);
        }
    }

    private static List<Trainer> GetTrainers()
    {
        List<Trainer> trainers = new List<Trainer>();
        string pokemonInput;
        while ((pokemonInput = Console.ReadLine()) != "Tournament")
        {
            string[] pokemonData = pokemonInput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string trainerName = pokemonData[0];
            string pokemonName = pokemonData[1];
            string pokemonElement = pokemonData[2];
            int pokemonHealth = int.Parse(pokemonData[3]);
            Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
            if (!trainers.Any(t => t.Name == trainerName))
            {
                Trainer trainer1 = new Trainer(trainerName);                
                trainers.Add(trainer1);
            }

            Trainer trainer = trainers.Single(t => t.Name == trainerName);
            trainer.Pokemons.Add(pokemon);
        }

        return trainers;
    }

    private static void TreatElementsEffect(List<Trainer> trainers)
    {
        string element;
        while ((element = Console.ReadLine()) != "End")
        {
            foreach (Trainer trainer in trainers)
            {
                if (trainer.Pokemons.Any(p => p.Element == element))
                {
                    trainer.AddBadge();
                }
                else
                {
                    trainer.Pokemons.ForEach(p => p.ReduceHealth());
                    trainer.ClearDeadPokemons();
                }
            }
        }
    }    
}