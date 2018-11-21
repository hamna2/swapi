using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwapiApiChallenge.Common;

namespace SwapiApiChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            NinjectServiceBinder.RegisterServices();
            var stopAggragator= NinjectServiceBinder.Resolve<IStarShipConsumableAggregartion>();

            stopAggragator.Calculate(1000000);

            Console.Read();
        }
    }
}
