using System;
using System.Collections.Generic;
using System.Linq;
using ParkingCalculation.Engine.Handler;

namespace ParkingCalculation.Engine.Domain.ParkingHandlerHelper
{
    interface IParkingHandlerTypeProvider
    {
        IEnumerable<Type> GetParkingHandlerTypes();
    }
    class ParkingHandlerTypeProvider : IParkingHandlerTypeProvider
    {
        static IEnumerable<Type> types;
        public IEnumerable<Type> GetParkingHandlerTypes()
        {
            GetAll();
            return types;
        }
        static void GetAll() =>  types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes().Where(t => (typeof(IParkingRateHandler)).IsAssignableFrom(t)))
            .Where(u => !u.IsAbstract && u.IsSubclassOf(typeof(ParkingRateHandler)));
    }
}
