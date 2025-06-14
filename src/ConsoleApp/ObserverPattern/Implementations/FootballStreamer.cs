using ConsoleApp.ObserverPattern.Abstractions;
using ConsoleApp.ObserverPattern.Enums;

namespace ConsoleApp.ObserverPattern.Implementations
{
    public class FootballStreamer : SportStreamer<FootballEvent>, IFootballStreamer
    {
        public FootballStreamer(DateTime start, Sports sport) : base(start, sport)
        {

        }

        public void CreateCardEvent(string player, string team, string card)
        {
            var description = $"El jugador {player} del equipo {team} ha obtenido una tarjeta {card}";

            var sportEvent = new FootballEvent(Start, description);

            _events.Add(sportEvent);

            Notify(sportEvent);
        }

        public void CreateGoalEvent(string player, string team)
        {
            var description = $"El jugador {player} del equipo {team} ha hecho una GOOOOOOL";

            var sportEvent = new FootballEvent(Start, description);

            _events.Add(sportEvent);

            Notify(sportEvent);
        }
    }
}
