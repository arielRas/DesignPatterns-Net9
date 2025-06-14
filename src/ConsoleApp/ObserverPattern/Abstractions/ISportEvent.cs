namespace ConsoleApp.ObserverPattern.Abstractions
{
    public interface ISportEvent
    {
        DateTime OccurredAt {  get; set; }
        TimeSpan MatchMinutes { get; set; }
        string Description { get; set; }
    }
}
