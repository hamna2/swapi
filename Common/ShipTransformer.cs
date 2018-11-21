using System.Collections.Generic;
using System.Linq;
using SwapiApiChallenge.Exceptions;
using SwapiApiChallenge.Interfaces;

namespace SwapiApiChallenge.Common
{
    public class ShipTransformer : IShipTransformer
    {
        private readonly IConsumableConverter _consumableConverter;

        public ShipTransformer(IConsumableConverter consumableConverter)
        {
            _consumableConverter = consumableConverter;
        }

        public IEnumerable<ShipViewModel> ToViewModel(IEnumerable<ShipModel> models)
        {
            return models.Select(ConvertToViewModel);
        }

        public ShipViewModel ToViewModel(ShipModel model)
        {
            return ConvertToViewModel(model);
        }

        private ShipViewModel ConvertToViewModel(ShipModel shipModel)
        {
            var view = new ShipViewModel
            {
                Name = shipModel.Name,
                Type = shipModel.Type,
                Model = shipModel.Model,

            };

            if (!int.TryParse(shipModel.MGLT, out var mglt))
            {
                throw new ConsumableConversionExecption("MGLT not in good format - do separte expection in next life");
            }

            view.MGLT = mglt;
            view.DistanceCoversInADay = view.MGLT * 24;
            view.ConsumablesInDays = _consumableConverter.Convert(shipModel.Consumables);

            return view;
            
        }

    }
}