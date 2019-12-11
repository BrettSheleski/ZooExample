using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo.Animals.Fish
{
    public class Guppy : Fish
    {
        protected override double GetInitialMass()
        {
            return GetRandomNumber(.25, .5);
        }
    }
}
