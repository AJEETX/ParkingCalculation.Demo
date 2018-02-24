using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParkingCalculation.Engine.Domain.ParkingHandlerHelper;
using ParkingCalculation.Engine.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCalculation.Engine.Domain.ParkingHandlerHelper.Tests
{
    [TestClass()]
    public class ParkingRateHandlerProviderTests
    {
        Mock<IEarlyBirdIParkingRateHandler> moqEarlyBirdIParkingRateHandler;
        Mock<INiteParkingRateHandler> moqNiteParkingRateHandler;
        Mock<IWeekendParkingRateHandler> moqWeekendParkingRateHandler;
        Mock<IStandardParkingRateHandler> moqStandardParkingRateHandler;
        [TestInitialize]
        public void Init()
        {
            moqEarlyBirdIParkingRateHandler = new Mock<IEarlyBirdIParkingRateHandler>();
            moqNiteParkingRateHandler = new Mock<INiteParkingRateHandler>();
            moqWeekendParkingRateHandler = new Mock<IWeekendParkingRateHandler>();
            moqStandardParkingRateHandler = new Mock<IStandardParkingRateHandler>();
        }
        [TestCleanup]
        public void CleanUp()
        {
            moqEarlyBirdIParkingRateHandler = null;moqNiteParkingRateHandler = null;
            moqWeekendParkingRateHandler = null;moqStandardParkingRateHandler = null;
        }
        [TestMethod()]
        public void ParkingRateHandlerProviderGetParkingHandlerTest_returns_collection_of_rate_handlers()
        {
            //given
            var sut = new ParkingRateHandlerProvider(moqEarlyBirdIParkingRateHandler.Object, moqNiteParkingRateHandler.Object,
                moqWeekendParkingRateHandler.Object, moqStandardParkingRateHandler.Object);

            //when
            var result = sut.GetParkingHandler();

            //then
            Assert.IsInstanceOfType(result, typeof(IEnumerable<IParkingRateHandler>));

        }
    }
}