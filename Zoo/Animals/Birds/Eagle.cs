using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo.Animals.Birds
{
    public class Eagle : Bird
    {
        public override void Move()
        {
            Console.WriteLine("Fly like an eagle");
        }

        protected override double GetInitialMass()
        {
            return GetRandomNumber(2.5, 4.47);
        }
    }
}
