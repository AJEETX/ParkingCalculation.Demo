using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingCalculation.Engine.Domain.ParkingHandlerHelper;
using ParkingCalculation.Engine.Handler;
using ParkingCalculation.Engine.Model;

namespace ParkingCalculation.Engine.Domain
{
    public interface IParkingRateHandlersSetting
    {
        ParkingRateHandler Set { get; }
    }
    public class ParkingRateHandlersSetting : IParkingRateHandlersSetting
    {
        IParkingHandlersProvider _IParkingHandlersProvider;
        public ParkingRateHandlersSetting(IParkingHandlersProvider IParkingHandlersProvider)
        {
            _IParkingHandlersProvider = IParkingHandlersProvider;
        }
        public ParkingRateHandler Set
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
