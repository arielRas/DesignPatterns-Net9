using ConsoleApp.ObserverPattern.Abstractions;
using ConsoleApp.ObserverPattern.Implementations;

namespace ConsoleApp.ObserverPattern.Abstractions
{
    public interface IBoxingStreamer : ISportStreamer<BoxingEvent>
    {
        void CreateKnockOutEvent(int round, string fallenFighter);
        void CreateEndRoundEvent(int round);

    }
}
