using ConsoleApp.ObserverPattern.Abstractions;
using System;

namespace ConsoleApp.ObserverPattern.Implementations
{
    public class FootballEvent : ISportEvent
    {
        public FootballEvent(DateTime matchStart, string description)
        {
            OccurredAt = DateTime.Now;
            MatchMinutes = matchStart - OccurredAt;
            Description = description;
        }

        public DateTime OccurredAt { get; set; }
        public TimeSpan MatchMinutes { get; set; }
        public string Description { get; set; }
    }
}
