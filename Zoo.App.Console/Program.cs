using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Zoo.Animals;

namespace Zoo.App.Console
{
    class Program
    {
        public TextWriter Writer { get; }
        public TextReader Reader { get; }
        public Type[] AnimalTypes { get; }
        public Zoo Zoo { get; } = new Zoo();

        public Program(TextWriter textWriter, TextReader textReader)
        {
            Writer = textWriter;
            Reader = textReader;

            this.AnimalTypes = GetAnimalTypes().ToArray();
        }

        private IEnumerable<Type> GetAnimalTypes()
        {
            Type animalType = typeof(Animals.Animal);
            Assembly assembly = animalType.Assembly;

            return assembly.ExportedTypes.Where(t => !t.IsAbstract && animalType.IsAssignableFrom(t));
        }

        static async Task Main(string[] args)
        {
            await Instance.ShowWelcomeAsync();
            await Instance.ShowOptionsAsync();

            
        }

        private async Task ShowWelcomeAsync()
        {
            await Writer.WriteLineAsync("**************************************");
            await Writer.WriteLineAsync("******** Welcome to your zoo! ********");
            await Writer.WriteLineAsync("**************************************");
            await Writer.WriteLineAsync();
        }

        private async Task ShowOptionsAsync()
        {
            await Writer.WriteLineAsync("What do you want to do?");
            await Writer.WriteLineAsync();
            await Writer.WriteLineAsync("A: Add an animal");
            await Writer.WriteLineAsync("L: List all animals");
            await Writer.WriteLineAsync();
            await Writer.WriteLineAsync("Q: Quit");


            var key = await ReadKeyAsync();

            switch (key.Key)
            {
                case ConsoleKey.A:
                    await ShowAddAnimalAsync();
                    break;
                case ConsoleKey.L:
                    await ListAnimalsAsync();
                    break;
                case ConsoleKey.Q:
                    return;
                default:
                    await Writer.WriteLineAsync();
                    await Writer.WriteLineAsync($"Unknown option '{key.KeyChar}'.  Please try again");
                    await Task.Delay(500);
                    await ClearScreenAsync();
                    break;
            }

            await ShowOptionsAsync();

        }

        Random Random { get; } = new Random((int)DateTime.Now.Ticks);

        private async Task ShowAddAnimalAsync()
        {
            await ClearScreenAsync();
            await Writer.WriteLineAsync("==== Add Animal ====");
            await Writer.WriteLineAsync("What kind of animal do you want to add?");
            await Writer.WriteLineAsync();


            Type type;
            for(int i = 0; i < this.AnimalTypes.Length; ++i)
            {
                type = this.AnimalTypes[i];
                await Writer.WriteLineAsync($"{(i + 1)} - {type.Name}");
            }

            await Writer.WriteAsync("Enter the number of the animal you want to add and press enter: ");

            string choice = await Reader.ReadLineAsync();

            int choiceNumber;

            if (string.IsNullOrWhiteSpace(choice))
            {
                return;
            }
            else if (int.TryParse(choice, out choiceNumber))
            {
                // user chooses values 1-number of choices, need to convert to index of array

                --choiceNumber;

                if (choiceNumber > -1 && choiceNumber < AnimalTypes.Length)
                {
                    Animal a = (Animal)Activator.CreateInstance(AnimalTypes[choiceNumber]);

                    Zoo.Add(a);

                    await Writer.WriteLineAsync($"{AnimalTypes[choiceNumber].Name} Added!");
                    await Task.Delay(500);
                }
                else
                {
                    await Writer.WriteAsync("Invalid Selection.  Try again.");
                    await Task.Delay(500);
                    await ShowAddAnimalAsync();
                }
            }
            else
            {
                await Writer.WriteAsync("Invalid Selection.  Try again.");
                await Task.Delay(500);
                await ShowAddAnimalAsync();
            }

        }

        private async Task ListAnimalsAsync()
        {
            await ClearScreenAsync();
            await Writer.WriteLineAsync("==== Here's my animals ====");

            await Writer.WriteLineAsync();
            await Writer.WriteLineAsync("Name\tMass");
            await Writer.WriteLineAsync("___________________________");
            int i = 1;
            foreach(var animal in Zoo.GetAnimals())
            {
                await Writer.WriteLineAsync($"{i} - {animal.GetType().Name}\t{animal.Mass:n3}kg");

                ++i;
            }

            await Writer.WriteLineAsync("Press any key to continue...");
            await ReadKeyAsync();
        }

        private async Task ClearScreenAsync()
        {
            await Task.Factory.StartNew(System.Console.Clear);
        }
        private async Task<ConsoleKeyInfo> ReadKeyAsync()
        {
            return await Task.Factory.StartNew(System.Console.ReadKey);
        }

        public static Program Instance { get; } = new Program(System.Console.Out, System.Console.In);
    }
}
