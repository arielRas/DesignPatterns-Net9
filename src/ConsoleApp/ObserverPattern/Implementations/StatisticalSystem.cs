using ConsoleApp.ObserverPattern.Abstractions;

namespace ConsoleApp.ObserverPattern.Implementations
{
    public class StatisticalSystem : ISubscriber
    {
        private static List<ISportEvent> events;
        public Guid Id { get; set; }

        public StatisticalSystem(Guid id)
        {
            Id = id;
            events = new List<ISportEvent>();    
        }

        public void Update(ISportEvent sportEvent)
        {
            Console.WriteLine("\n\nPersistencia en sistema estadistico\n");

            events.Add(sportEvent);

            Console.WriteLine($"\nGuardando evento para analisis - {sportEvent.Description}");
        }
    }
}
