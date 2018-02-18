using System;
using System.Globalization;
using ParkingCalculation.Engine.Model;

namespace ParkingCalculation.Engine.Domain
{
    public interface IProgramRunner
    {
        IParkingReceipt Generate(string entry, string exit);
    }
    public class ProgramRunner: IProgramRunner
    {
        ParkingCalculationEngineManager _ParkingCalculationEngineManager;
        public ProgramRunner(ParkingCalculationEngineManager ParkingCalculationEngineManager)
        {
            _ParkingCalculationEngineManager = ParkingCalculationEngineManager;
        }

        public IParkingReceipt Generate(string entry, string exit)
        {
            if (entry.DateValidated()==DateTime.MinValue || exit.DateValidated()==DateTime.MinValue)
                return new ParkingReceipt { Erred = true };
            return  _ParkingCalculationEngineManager.GenerateParkingCharge(entry.DateValidated(), exit.DateValidated());
        }
    }
}
