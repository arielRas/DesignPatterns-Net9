using ConsoleApp.ObserverPattern.Implementations;

namespace ConsoleApp.ObserverPattern.Abstractions
{
    public interface IFootballStreamer : ISportStreamer<FootballEvent>
    {
        void CreateGoalEvent(string player, string team);
        void CreateCardEvent(string player, string team, string card);
    }
}
