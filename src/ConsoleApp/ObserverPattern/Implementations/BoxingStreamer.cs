using ConsoleApp.ObserverPattern.Abstractions;
using ConsoleApp.ObserverPattern.Enums;
using System;

namespace ConsoleApp.ObserverPattern.Implementations
{
    public class BoxingStreamer : SportStreamer<BoxingEvent>, IBoxingStreamer
    {
        public BoxingStreamer(DateTime start, Sports sport) : base(start, sport)
        {
            
        }

        public void CreateEndRoundEvent(int round)
        {
            var description = $"finaliza el round {round}";

            var sportEvent = new BoxingEvent(Start, description);

            _events.Add(sportEvent);

            Notify(sportEvent);
        }

        public void CreateKnockOutEvent(int round, string fallenFighter)
        {
            var description = $"del round {round}, el peleador {fallenFighter} es nockeado";

            var sportEvent = new BoxingEvent(Start, description);

            _events.Add(sportEvent);

            Notify(sportEvent);
        }
    }
}
