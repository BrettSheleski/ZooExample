using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Zoo.Animals;

namespace Zoo.App.Mobile
{
    internal class AddAnimalViewModel
    {

        public AddAnimalViewModel(Zoo zoo, INavigation navigation, Func<Task> completionCallback)
        {
            this.Zoo = zoo;
            this.Navigation = navigation;
            this.CompletionCallback = completionCallback;

            PopulateAddCommands();
        }

        private void PopulateAddCommands()
        {
            Type animalType = typeof(Animals.Animal);
            var assembly = animalType.Assembly;

            foreach (var type in assembly.ExportedTypes.Where(t => !t.IsAbstract && animalType.IsAssignableFrom(t)).OrderBy(x => x.Name))
            {
                Type nonClosureType = type;
                AnimalTypes.Add(new AnimalTypeViewModel(nonClosureType, new AsyncCommand(async () => await AddAsync(nonClosureType))));
            }
        }

        public Func<Task> CompletionCallback { get; }
        public Zoo Zoo { get; }
        public INavigation Navigation { get; }

        async Task AddAsync(Type animalType)
        {
            Animal a = (Animal)Activator.CreateInstance(animalType);

            this.Zoo.Add(a);

            await this.Navigation.PopAsync();
            await CompletionCallback?.Invoke();
        }

        public ObservableCollection<AnimalTypeViewModel> AnimalTypes { get; } = new ObservableCollection<AnimalTypeViewModel>();

        public class AnimalTypeViewModel : ViewModel
        {
            public AnimalTypeViewModel(Type animalType, ICommand command)
            {
                this.Name = animalType.Name;
                this.Command = command;
            }

            public string Name { get; }
            public ICommand Command { get; }
        }
    }
}