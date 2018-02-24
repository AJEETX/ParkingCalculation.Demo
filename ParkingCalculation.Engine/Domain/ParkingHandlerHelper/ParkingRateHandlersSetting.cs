using System.Linq;
using ParkingCalculation.Engine.Domain.ParkingHandlerHelper;
using ParkingCalculation.Engine.Handler;

namespace ParkingCalculation.Engine.Domain
{
     interface IParkingRateHandlersSetting
    {
        IParkingRateHandler Set { get; }
    }
    class ParkingRateHandlersSetting : IParkingRateHandlersSetting
    {
        IParkingHandlersProvider _IParkingHandlersProvider;
        public ParkingRateHandlersSetting(IParkingHandlersProvider IParkingHandlersProvider)
        {
            _IParkingHandlersProvider = IParkingHandlersProvider;
        }
        public IParkingRateHandler Set
        {
            get {
                var handlers = _IParkingHandlersProvider.GetParkingHandler().ToList();

                for (int i = 0; i < handlers.Count - 1; i++) {

                    handlers[i].SetNextHandler(handlers[i + 1]);

                } return handlers.FirstOrDefault();
            }
        }
    }
}
