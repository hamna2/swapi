using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwapiApiChallenge.Common;
using SwapiApiChallenge.Exceptions;
using SwapiApiChallenge.Interfaces;

namespace SwapiApiChallenge
{
    public class SwapiOrchestrator : ISwapiOrchestrator
    {
        private readonly ISwapiServiceProxy _serviceProxy;
        private readonly IShipTransformer _shipTransformer;

        public SwapiOrchestrator(ISwapiServiceProxy serviceProxy,IShipTransformer shipTransformer)
        {
            _serviceProxy = serviceProxy?? throw  new ArgumentNullException(nameof(serviceProxy));
            _shipTransformer = shipTransformer?? throw  new ArgumentNullException(nameof(shipTransformer));
        }

        public async Task<IEnumerable<ShipViewModel>> GetAll()
        {
            var shipModels = await _serviceProxy.GetAll();

            var viewModels = _shipTransformer.ToViewModel(shipModels);

            return viewModels;
        }

        public async Task<ShipViewModel> Get(int id)
        {
            var shipModel = await _serviceProxy.Get(id);
            return _shipTransformer.ToViewModel(shipModel);
        }
        
    }



}
