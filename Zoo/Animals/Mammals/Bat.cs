using System;

namespace Zoo.Animals.Mammals
{
    public class Bat : Mammal
    {
        public override void Move()
        {
            Console.WriteLine("Fly like a bat");
        }

        protected override double GetInitialMass()
        {
            return GetRandomNumber(.5, 1.5);
        }
    }
}
