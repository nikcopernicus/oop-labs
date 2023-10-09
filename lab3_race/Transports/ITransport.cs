namespace lab3_race
{
    interface ITransport
    {
        string Name { get; set; }
        double Speed { get; set; }
        double TimeToFinish(double distance);
    }
}
