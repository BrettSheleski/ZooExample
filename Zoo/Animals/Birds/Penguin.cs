using System;

namespace Zoo.Animals.Birds
{
    public class Penguin : Bird
    {
        public override void Move()
        {
            Console.WriteLine("Waddle like an Penguin");
        }

        protected override double GetInitialMass()
        {
            return GetRandomNumber(30, 40);
        }
    }
}
