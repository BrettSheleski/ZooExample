using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo.Animals.Fish
{
    public class Flounder : Fish
    {
        protected override double GetInitialMass()
        {
            return GetRandomNumber(1, 2);
        }
    }
}
