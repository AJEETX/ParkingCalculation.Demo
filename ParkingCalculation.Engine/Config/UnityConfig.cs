using ParkingCalculation.Engine.Domain;
using ParkingCalculation.Engine.Domain.ParkingHandlerHelper;
using Unity;

namespace ParkingCalculation.Engine.Config
{
    public class UnityConfig
    {
        public static ProgramRunner GetProgramRunner()
        {
            IUnityContainer unitycontainer = new UnityContainer();
            unitycontainer.RegisterType<IParkingHandlersProvider, ParkingHandlersProvider>();
            unitycontainer.RegisterType<IParkingHandlerTypeProvider, ParkingHandlerTypeProvider>();
            unitycontainer.RegisterType<IParkingRateHandlersSetting, ParkingRateHandlersSetting>();
            unitycontainer.RegisterType<IParkingCalculationEngineManager, ParkingCalculationEngineManager>();
            return unitycontainer.Resolve<ProgramRunner>();
        }
    }
}
