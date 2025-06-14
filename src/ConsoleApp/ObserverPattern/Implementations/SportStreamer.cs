using ConsoleApp.ObserverPattern.Abstractions;
using ConsoleApp.ObserverPattern.Enums;

namespace ConsoleApp.ObserverPattern.Implementations
{
    public abstract class SportStreamer<T> : ISportStreamer<T> where T : class, ISportEvent
    {
        protected List<T> _events;
        protected List<ISubscriber> _subscribers;

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Sports Sport { get; set; }

        protected SportStreamer(DateTime start, Sports sport)
        {
            Start = start;
            Sport = sport;
            _events = new List<T>();
            _subscribers = new List<ISubscriber>();
        }
        public IEnumerable<T> Events => _events;

        public IEnumerable<ISubscriber> Subscribers => _subscribers;

        public void Notify(T sportEvent)
        {
            if (_subscribers.Any())
                _subscribers.ForEach(x => x.Update(sportEvent));
        }

        public void Subscribe(ISubscriber subscriber)
        {
            if(!_subscribers.Any(x => x.Id == subscriber.Id))
                _subscribers.Add(subscriber);
        }

        public void Unsubscribe(ISubscriber subscriber)
        {
            var existingSubscriber = _subscribers.FirstOrDefault(x => x.Id == subscriber.Id);

            if (existingSubscriber != null)
                _subscribers.Remove(existingSubscriber);
        }
    }
}
