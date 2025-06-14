using ConsoleApp.ObserverPattern.Abstractions;

namespace ConsoleApp.ObserverPattern.Implementations
{
    public class PhoneNotificator : ISubscriber
    {
        private static List<string> _phones;
        public Guid Id { get; set ; }

        public PhoneNotificator(Guid id)
        {
            Id = id;

            _phones = new List<string>{ "1169874521", "1169845871", "1169756691" };
        }

        public void Update(ISportEvent sportEvent)
        {
            Console.WriteLine("\n\nNotificacion telefonica\n");

            _phones.ForEach(x =>
            {
                Console.WriteLine($"Notificando a numero: {x} - Hora de evento: {sportEvent.OccurredAt} - A los {sportEvent.MatchMinutes.TotalMinutes} del inicio {sportEvent.Description}");
            });
        }
    }
}
