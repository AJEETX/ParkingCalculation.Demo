using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingCalculation.Engine.Domain.ParkingHandlerHelper;
using ParkingCalculation.Engine.Model;

namespace ParkingCalculation.Engine.Domain
{
    public interface IProgramRunner
    {
        IParkingReceipt Generate(DateTime entry, DateTime exit);
    }
    public class ProgramRunner: IProgramRunner
    {
        ParkingCalculationEngineManager _ParkingCalculationEngineManager;
        public ProgramRunner(ParkingCalculationEngineManager ParkingCalculationEngineManager)
        {
            _ParkingCalculationEngineManager = ParkingCalculationEngineManager;
        }

        public IParkingReceipt Generate(DateTime entry, DateTime exit)
        {
            return _ParkingCalculationEngineManager.GenerateParkingCharge(entry, exit);
        }
    }
}
