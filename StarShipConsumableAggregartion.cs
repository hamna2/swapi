using System;
using SwapiApiChallenge.Interfaces;

namespace SwapiApiChallenge
{
    public interface IStarShipConsumableAggregartion
    {
        void Calculate(int milage);
    }
    public class StarShipConsumableAggregartion :IStarShipConsumableAggregartion
    {
        private readonly ISwapiOrchestrator _swapiOrchestrator;

        public StarShipConsumableAggregartion(ISwapiOrchestrator swapiOrchestrator)
        {
            _swapiOrchestrator = swapiOrchestrator;
        }
        public  void Calculate(int milage)
        {
            var ships =  _swapiOrchestrator.GetAll().Result;

            foreach (var ship in ships)
            {
                var stopsToMake = milage/(ship.DistanceCoversInADay * ship.ConsumablesInDays);
                Console.WriteLine($"Ship:{ship.Name} make {stopsToMake} stops.");
            }

        }
    }
}