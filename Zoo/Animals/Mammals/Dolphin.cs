using System;

namespace Zoo.Animals.Mammals
{
    public class Dolphin : Mammal
    {
        public override void Move()
        {
            Console.WriteLine("Swim like a dolphin");
        }

        protected override double GetInitialMass()
        {
            return GetRandomNumber(600, 700);
        }
    }
}
