using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo.Animals.Birds
{
    public class Robin : Bird
    {
        public override void Move()
        {
            Console.WriteLine("Fly like a robin");
        }

        protected override double GetInitialMass()
        {
            return GetRandomNumber(0.25, 1);
        }
    }
}
