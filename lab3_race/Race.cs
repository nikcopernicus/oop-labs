using System;
using System.Collections.Generic;


namespace lab3_race
{
    class Race<T> where T : ITransport
    {
        public double Distance { get; set; }
        public List<T> RaceMembers { get; set; }
        public Race(double dist)
        {
            Distance = dist;
            RaceMembers = new List<T>();
        }
        public void AddMember(T Member)
        {
            RaceMembers.Add(Member);
        }
        public void AddMembers(List<T> Members)
        {
            foreach (T Member in Members)
            {
                AddMember(Member);
            }
        }
        public T WinRace()
        {
            T winner = default(T);
            double winnerTime = -1;
            foreach (T Member in RaceMembers)
            {
                double memberTime = Member.TimeToFinish(Distance);
                if (winnerTime == -1 || memberTime < winnerTime)
                {
                    winner = Member;
                    winnerTime = memberTime;
                }
            }
            return winner;
        }
    }
}

