namespace ConsoleApp.ObserverPattern.Abstractions
{
    public interface IPublisher<T> where T : class, ISportEvent
    {
        IEnumerable<ISubscriber> Subscribers { get; }
        void Subscribe(ISubscriber subscriber);
        void Unsubscribe(ISubscriber subscriber);
        void Notify(T sportEvent);
    }
}
