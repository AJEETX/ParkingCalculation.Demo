using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParkingCalculation.Engine.Domain;
using ParkingCalculation.Engine.Domain.ParkingHandlerHelper;
using ParkingCalculation.Engine.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCalculation.Engine.Domain.Tests
{
    [TestClass()]
    public class ParkingRateHandlersSettingTests
    {
        Mock<IParkingHandlersProvider> moqParkingHandlersProvider;

        [TestInitialize]
        public void Init()
        {
            var handlers = new List<IParkingRateHandler> { new EarlyBirdRateHandler(),new NiteRateHandler(),new WeekendRateHandler(),new StandardRateHandler() };
            moqParkingHandlersProvider = new Mock<IParkingHandlersProvider>();
            moqParkingHandlersProvider.Setup(m => m.GetParkingHandler()).Returns(handlers);
        }
        [TestCleanup]
        public void CleanUp()
        {
            moqParkingHandlersProvider = null;
        }
        [TestMethod()]
        public void ParkingRateHandlersSettingParkingRateHandlersSettingTest_returns_early_bird_rate_handler()
        {
            //given
            var sut = new ParkingRateHandlersSetting(moqParkingHandlersProvider.Object);

            //when
            var result = sut.Set;

            //then
            Assert.IsInstanceOfType(result,typeof(EarlyBirdRateHandler));
        }
    }
}