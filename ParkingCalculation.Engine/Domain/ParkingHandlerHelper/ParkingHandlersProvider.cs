using System;
using System.Collections.Generic;
using System.Linq;
using ParkingCalculation.Engine.Handler;

namespace ParkingCalculation.Engine.Domain.ParkingHandlerHelper
{
    public interface IParkingHandlersProvider
    {
        IEnumerable<ParkingRateHandler> GetParkingHandler();
    }
    public class ParkingHandlersProvider : IParkingHandlersProvider
    {
        IParkingHandlerTypeProvider _IParkingHandlerTypeProvider; static IEnumerable<Type> types; static List<ParkingRateHandler> parkingRateHandler;
        public ParkingHandlersProvider(IParkingHandlerTypeProvider IParkingHandlerTypeProvider)
        {
            _IParkingHandlerTypeProvider = IParkingHandlerTypeProvider;
        }
        public IEnumerable<ParkingRateHandler> GetParkingHandler()
        {
            Get();
            return parkingRateHandler;
        }
        void Get()
        {
            types = _IParkingHandlerTypeProvider.GetParkingHandlerTypes().OrderBy(o=>o.Name);

            parkingRateHandler = new List<ParkingRateHandler>();

            foreach (var type in types) {

                var handler = Activator.CreateInstance(type) as ParkingRateHandler;

                if (handler == null) continue;

                parkingRateHandler.Add(handler);
            }
        }
        
    }
}
