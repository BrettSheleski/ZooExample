using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Zoo.Animals;

namespace Zoo.App.Mobile
{
    public class MainPageViewModel : ViewModel
    {
        public Zoo Zoo { get; } = new Zoo();
        public AsyncCommand AddAnimalCommand { get; }
        public AsyncCommand PopulateAnimalsCommand { get; }
        public INavigation Navigation { get; }

        public MainPageViewModel(INavigation navigation)
        {
            this.AddAnimalCommand = new AsyncCommand(AddAnimalAsync);
            this.PopulateAnimalsCommand = new AsyncCommand(PopulateAnimalsAsync);
            this.Navigation = navigation;
        }

        public ObservableCollection<AnimalInfo> Animals { get; } = new ObservableCollection<AnimalInfo>();


        public Task PopulateAnimalsAsync()
        {
            var animals = Zoo.GetAnimals();

            HashSet<Animal> existingAnimals = new HashSet<Animal>(this.Animals.Select(x => x.Animal));

            foreach(var animal in animals)
            {
                if (!existingAnimals.Contains(animal))
                {
                    this.Animals.Add(new AnimalInfo(animal));
                }
            }

            return Task.CompletedTask;
        }


        private async Task AddAnimalAsync()
        {
            Page page = new AddAnimalPage();
            var vm = new AddAnimalViewModel(this.Zoo, this.Navigation, PopulateAnimalsAsync);

            page.BindingContext = vm;

            await this.Navigation.PushAsync(page);
        }

        public class AnimalInfo
        {
            public AnimalInfo(Animal animal)
            {
                this.Animal = animal;

                this.TypeName = animal.GetType().Name;
            }

            public string TypeName { get; }
            public Animal Animal { get; }
        }
    }
}
