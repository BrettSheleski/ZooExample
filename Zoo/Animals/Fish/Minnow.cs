namespace Zoo.Animals.Fish
{
    public class Minnow : Fish
    {
        protected override double GetInitialMass()
        {
            return GetRandomNumber(.1, .2);
        }
    }
}
