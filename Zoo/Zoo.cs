using System;
using System.Collections.Generic;
using Zoo.Animals;

namespace Zoo
{
    public class Zoo
    {

        private readonly List<Animal> _allAnimals = new List<Animal>();

        public void Add(Animal animal)
        {
            _allAnimals.Add(animal);
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return _allAnimals;
        }
    }

}
