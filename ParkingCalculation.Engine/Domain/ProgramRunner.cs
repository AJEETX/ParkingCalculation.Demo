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
        DateTime entryDateTime, exitDateTime; CultureInfo culture = CultureInfo.InvariantCulture; DateTimeStyles styles = DateTimeStyles.None;
        ParkingCalculationEngineManager _ParkingCalculationEngineManager; string format = "d/M/yyyy H:m";
        public ProgramRunner(ParkingCalculationEngineManager ParkingCalculationEngineManager)
        {
            _ParkingCalculationEngineManager = ParkingCalculationEngineManager;
        }

        public IParkingReceipt Generate(string entry, string exit)
        {
            bool validEntry = DateTime.TryParseExact(entry, format, culture, styles, out entryDateTime);
            bool validExit = DateTime.TryParseExact(exit, format, culture, styles, out exitDateTime);
            if (validEntry && validExit)
                return _ParkingCalculationEngineManager.GenerateParkingCharge(entryDateTime, exitDateTime);
            else
                return new ParkingReceipt { Erred = true };
        }
    }
}
