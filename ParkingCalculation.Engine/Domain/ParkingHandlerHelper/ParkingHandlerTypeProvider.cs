using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingCalculation.Engine.Handler;

namespace ParkingCalculation.Engine.Domain.ParkingHandlerHelper
{
    public interface IParkingHandlerTypeProvider
    {
        IEnumerable<Type> GetParkingHandlerTypes();
    }
    public class ParkingHandlerTypeProvider : IParkingHandlerTypeProvider
    {
        public IEnumerable<Type> GetParkingHandlerTypes()
        {
            GetAll();
            return types;
        }
        static void GetAll()
        {
            types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes().Where(t =>(typeof(ParkingRateHandler)).IsAssignableFrom(t)))
                .Where(u => !u.IsAbstract && u.IsSubclassOf(typeof(ParkingRateHandler)));

        }
        static IEnumerable<Type> types;
    }
}
