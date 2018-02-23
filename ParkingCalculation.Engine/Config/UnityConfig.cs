using ParkingCalculation.Engine.Domain;
using ParkingCalculation.Engine.Domain.ParkingHandlerHelper;
using ParkingCalculation.Engine.Handler;
using Unity;

namespace ParkingCalculation.Engine.Config
{
    public class UnityConfig
    {
        public static IProgramRunner GetProgramRunner()
        {
            IUnityContainer unitycontainer = new UnityContainer();
            unitycontainer.RegisterType<IProgramRunner, ProgramRunner>();
            unitycontainer.RegisterType<IParkingHandlersProvider, ParkingRateHandlerProvider>();
            unitycontainer.RegisterType<IEarlyBirdIParkingRateHandler, EarlyBirdRateHandler>();
            unitycontainer.RegisterType<INiteParkingRateHandler, NiteRateHandler>();
            unitycontainer.RegisterType<IWeekendParkingRateHandler, WeekendRateHandler>();
            unitycontainer.RegisterType<IStandardParkingRateHandler, StandardRateHandler>();

            unitycontainer.RegisterType<IParkingRateHandlersSetting, ParkingRateHandlersSetting>();
            unitycontainer.RegisterType<IParkingCalculationEngineManager, ParkingCalculationEngineManager>();
            return unitycontainer.Resolve<IProgramRunner>();
        }
    }
}
