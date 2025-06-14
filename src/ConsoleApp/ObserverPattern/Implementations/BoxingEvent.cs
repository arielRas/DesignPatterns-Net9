using ConsoleApp.ObserverPattern.Abstractions;

namespace ConsoleApp.ObserverPattern.Implementations
{
    public class BoxingEvent : ISportEvent
    {

        public BoxingEvent(DateTime matchStart, string description)
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
