using System.Collections.Generic;
using SwapiApiChallenge.Common;

namespace SwapiApiChallenge
{
    public interface IShipTransformer
    {
        IEnumerable<ShipViewModel> ToViewModel(IEnumerable<ShipModel> models);
        ShipViewModel ToViewModel(ShipModel model);
    }
}