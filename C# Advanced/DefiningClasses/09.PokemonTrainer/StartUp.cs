using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Program
    {
        static void Main(string[] args)
        {
            var trainers = new HashSet<Trainer>();

            while (true)
            {
                var input = Console.ReadLine().Split();

                if (input[0] == "Tournament")
                {
                    break;
                }

                var trainerName = input[0];
                var pokemonName = input[1];
                var pokemonElement = input[2];
                var pokemonHealth = int.Parse(input[3]);
                var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                var isTrainerExist = false;
                foreach (var master in trainers)
                {
                    if (master.Name == trainerName)
                    {
                        isTrainerExist = true;
                        break;
                    }
                }
                if (isTrainerExist == false)
                {
                    var trainer = new Trainer(trainerName);
                    trainers.Add(trainer);
                    trainer.AddPokemon(pokemon);
                }
                else
                {
                    trainers.SingleOrDefault(x => x.Name == trainerName).AddPokemon(pokemon);
                }




            }

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(x => x.Element == command))
                    {
                        trainer.AddBadge();
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Pokemons)
                        {
                            pokemon.Lose10Health();
                        }
                    }
                    trainer.Pokemons.RemoveAll(x => x.Health <= 0);
                }

            }

            Console.WriteLine(string.Join(Environment.NewLine, trainers.OrderByDescending(x => x.Badges)));
        }
    }
}
