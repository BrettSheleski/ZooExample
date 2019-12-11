using System;

namespace Zoo.Animals.Mammals
{
    public class Elephant : Mammal
    {
        public override void Move()
        {
            Console.WriteLine("Stomp like an Elephant");
        }
        protected override double GetInitialMass()
        {
            return GetRandomNumber(2300, 6500);
        }
    }
}
