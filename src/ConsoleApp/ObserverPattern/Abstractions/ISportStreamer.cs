using ConsoleApp.ObserverPattern.Enums;

namespace ConsoleApp.ObserverPattern.Abstractions
{
    public interface ISportStreamer<T> : IPublisher<T> where T : class, ISportEvent
    {        
        DateTime Start { get; set; }
        DateTime End { get; set; }
        Sports Sport { get; set; }
        IEnumerable<T> Events { get; }
    }
}
