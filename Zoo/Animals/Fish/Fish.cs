using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo.Animals.Fish
{
    public abstract class Fish : Animal
    {
        public override sealed void Move()
        {
            Swim();
        }

        public virtual void Swim()
        {
            Console.WriteLine("Swim like a fish");
        }
    }
}
