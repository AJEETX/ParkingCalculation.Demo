using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingCalculation.Engine.Handler;

namespace ParkingCalculation.Engine.Domain.ParkingHandlerHelper
{
    interface IParkingHandlersProvider
    {
        IEnumerable<IParkingRateHandler> GetParkingHandler();
    }
    class ParkingRateHandlerProvider : IParkingHandlersProvider
    {
        IEarlyBirdIParkingRateHandler _IEarlyBirdIParkingRateHandler;
        INiteParkingRateHandler _INiteParkingRateHandler;
        IWeekendParkingRateHandler _IWeekendParkingRateHandler;
        IStandardParkingRateHandler _IStandardParkingRateHandler;
        public ParkingRateHandlerProvider(IEarlyBirdIParkingRateHandler IEarlyBirdIParkingRateHandler, INiteParkingRateHandler INiteParkingRateHandler,
            IWeekendParkingRateHandler IWeekendParkingRateHandler, IStandardParkingRateHandler IStandardParkingRateHandler)
        {
            _IEarlyBirdIParkingRateHandler = IEarlyBirdIParkingRateHandler;_INiteParkingRateHandler = INiteParkingRateHandler;
            _IWeekendParkingRateHandler = IWeekendParkingRateHandler;_IStandardParkingRateHandler = IStandardParkingRateHandler;
        }
        public IEnumerable<IParkingRateHandler> GetParkingHandler()
        {
            var parkingRateHandlers = new List<IParkingRateHandler>();
            parkingRateHandlers.Add(_IEarlyBirdIParkingRateHandler);
            parkingRateHandlers.Add(_INiteParkingRateHandler);
            parkingRateHandlers.Add(_IWeekendParkingRateHandler);
            parkingRateHandlers.Add(_IStandardParkingRateHandler);
            return parkingRateHandlers.OrderBy(o=>o.Id) ;
        }
    }
}
