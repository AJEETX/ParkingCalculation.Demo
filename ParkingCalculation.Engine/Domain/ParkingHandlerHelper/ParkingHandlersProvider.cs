using System;
using System.Collections.Generic;
using System.Linq;
using ParkingCalculation.Engine.Handler;

namespace ParkingCalculation.Engine.Domain.ParkingHandlerHelper
{
     interface IParkingHandlersProvider
    {
        IEnumerable<IParkingRateHandler> GetParkingHandler();
    }
    class ParkingHandlersProvider : IParkingHandlersProvider
    {
        IParkingHandlerTypeProvider _IParkingHandlerTypeProvider; static IEnumerable<Type> types; static List<IParkingRateHandler> parkingRateHandler;
        public ParkingHandlersProvider(IParkingHandlerTypeProvider IParkingHandlerTypeProvider)
        {
            _IParkingHandlerTypeProvider = IParkingHandlerTypeProvider;
        }
        public IEnumerable<IParkingRateHandler> GetParkingHandler()
        {
            Get();
            return parkingRateHandler;
        }
        void Get()
        {
            types = _IParkingHandlerTypeProvider.GetParkingHandlerTypes().OrderBy(o=>o.Name);

            parkingRateHandler = new List<IParkingRateHandler>();

            foreach (var type in types) {

                var handler = Activator.CreateInstance(type) as IParkingRateHandler;

                if (handler == null) continue;

                parkingRateHandler.Add(handler);
            }
        }
    }
}
