namespace lab3_race
{
    abstract class LandTransport : ITransport
    {
        public string Name { get; set; }
        public double Speed { get; set; }
        public double RestTime { get; set; }
        public abstract double RestDuration(int i);
        public double TimeToFinish(double distance)
        {
            double time = distance / Speed;
            double rest = time / RestTime;
            for (int i = 1; i <= rest; i++)
            {
                time += RestDuration(i);
            }
            return time;
        }
    }
}
