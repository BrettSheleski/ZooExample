namespace Zoo.Animals.Fish
{
    public class Shark : Fish
    {
        protected override double GetInitialMass()
        {
            return GetRandomNumber(1900, 2300);
        }
    }
}
