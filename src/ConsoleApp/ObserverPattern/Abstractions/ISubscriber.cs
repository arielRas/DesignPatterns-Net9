namespace ConsoleApp.ObserverPattern.Abstractions
{
    public interface ISubscriber
    {
        Guid Id { get; set; }
        void Update(ISportEvent sportEvent);
    }
}
