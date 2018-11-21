using System.Collections.Generic;
using System.Threading.Tasks;
using SwapiApiChallenge.Common;

namespace SwapiApiChallenge.Interfaces
{
    public interface ISwapiOrchestrator
    {
       Task<IEnumerable<ShipViewModel>> GetAll();

        Task<ShipViewModel> Get(int id);
    }
}