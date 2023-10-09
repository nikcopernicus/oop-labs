namespace lab3_race
{
    abstract class AirTransport : ITransport
    {
        public string Name { get; set; }
        public double Speed { get; set; }
        public abstract double DistanceReducer(double distance);
        public double TimeToFinish(double distance)
        {
            return distance * (1 - DistanceReducer(distance)) / Speed;
        }
    }
}
