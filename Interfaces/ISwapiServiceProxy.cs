using System.Collections.Generic;
using System.Threading.Tasks;
using SwapiApiChallenge.Common;

namespace SwapiApiChallenge.Interfaces
{
    public interface ISwapiServiceProxy
    {
        Task<IEnumerable<ShipModel>> GetAll();
        Task<ShipModel> Get(int id);

    }
}