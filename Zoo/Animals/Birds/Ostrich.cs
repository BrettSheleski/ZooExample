using System;

namespace Zoo.Animals.Birds
{
    public class Ostrich : Bird
    {
        public override void Move()
        {
            Console.WriteLine("Run like an eagle");
        }

        protected override double GetInitialMass()
        {
            return GetRandomNumber(90, 130);
        }
    }
}
