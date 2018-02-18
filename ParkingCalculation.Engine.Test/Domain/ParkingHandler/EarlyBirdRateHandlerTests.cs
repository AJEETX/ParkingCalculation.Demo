using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParkingCalculation.Engine.Model;
using System;

namespace ParkingCalculation.Engine.Handler.Tests
{
    [TestClass()]
    public class EarlyBirdRateHandlerTests
    {
        [TestMethod()]
        public void EarlyBirdRateHandlerGetParkingChargesTest__Get_Correct_ParkingCharges()
        {
            //given
            DateTime entry = new DateTime(2018,2,19,9,20,00), exit = new DateTime(2018, 2, 19, 19, 50, 00);
            var moqParkingRateHandler = new Mock<ParkingRateHandler>();
            var sut=new EarlyBirdRateHandler();
            sut.SetNextHandler(moqParkingRateHandler.Object);

            //when
            var result = sut.GetParkingCharges(entry, exit);

            //then
            Assert.IsInstanceOfType(result, typeof(IParkingReceipt));
            Assert.IsTrue(result.RateType == RateType.EARLY);
        }
    }
}