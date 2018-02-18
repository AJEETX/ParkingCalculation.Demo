using ParkingCalculation.Engine.Domain;
using ParkingCalculation.Engine.Domain.ParkingHandlerHelper;
using Unity;

namespace ParkingCalculation.Engine.Config
{
    public class UnityConfig
    {
        public static IProgramRunner GetProgramRunner()
        {
            IUnityContainer unitycontainer = new UnityContainer();
            unitycontainer.RegisterType<IProgramRunner, ProgramRunner>();
            unitycontainer.RegisterType<IParkingHandlersProvider, ParkingHandlersProvider>();
            unitycontainer.RegisterType<IParkingHandlerTypeProvider, ParkingHandlerTypeProvider>();
            unitycontainer.RegisterType<IParkingRateHandlersSetting, ParkingRateHandlersSetting>();
            unitycontainer.RegisterType<IParkingCalculationEngineManager, ParkingCalculationEngineManager>();
            return unitycontainer.Resolve<IProgramRunner>();
        }
    }
}
