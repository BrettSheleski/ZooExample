using System;

namespace Zoo.Animals.Mammals
{
    public class Dog : Mammal
    {
        public override void Move()
        {
            Console.WriteLine("Run like a dog");
        }

        protected override double GetInitialMass()
        {
            return GetRandomNumber(5, 20);
        }
    }
}
