using System;
using ParkingCalculation.Engine.Domain;
using ParkingCalculation.Engine.Model;

namespace ParkingCalculation.Engine
{
    interface IParkingCalculationEngineManager
    {
        IParkingReceipt GenerateParkingCharge(DateTime entry, DateTime exit);
    }
    class ParkingCalculationEngineManager : IParkingCalculationEngineManager
    {
        IParkingRateHandlersSetting _IParkingRateHandlersSetting;
        public ParkingCalculationEngineManager(IParkingRateHandlersSetting IParkingRateHandlersSetting)
        {
            _IParkingRateHandlersSetting = IParkingRateHandlersSetting;
        }
        public IParkingReceipt GenerateParkingCharge(DateTime entry, DateTime exit)
        {
            var receipt = new ParkingReceipt { ParkingName="No Charge", ParkingPrice=0, Erred=true, RateType=RateType.NONE };
            if (entry>=exit)
                return receipt;
            return _IParkingRateHandlersSetting.Set.GetParkingCharges(entry,exit);
        }
    }
}
