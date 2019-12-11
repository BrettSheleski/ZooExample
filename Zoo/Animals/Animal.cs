using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo.Animals
{
    public abstract class Animal
    {
        public Animal()
        {
            this.Mass = GetInitialMass();
        }

        protected abstract double GetInitialMass();

        public abstract void Move();

        public double Mass { get; protected set; }



        private static readonly Random _random = new Random((int)DateTime.Now.Ticks);

        protected static double GetRandomNumber(double min, double max)
        {
            return min + (_random.NextDouble() * (max - min));
        }
    }
}
