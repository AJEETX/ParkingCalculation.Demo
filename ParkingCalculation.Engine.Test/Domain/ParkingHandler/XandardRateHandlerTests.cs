using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingCalculation.Engine.Model;
using System;

namespace ParkingCalculation.Engine.Handler.Tests
{
    [TestClass()]
    public class XandardRateHandlerTests
    {
        [TestMethod()]
        public void XandardRateHandlerGetParkingChargesTest_Get_Correct_ParkingCharges()
        {
            //given
            var rndm = new Random();
            DateTime entry=DateTime.Now.AddHours(-rndm.Next(50, 100)),exit= DateTime.Now.AddHours(-rndm.Next(20));
            var sut = new XandardRateHandler();

            //when
            var result = sut.GetParkingCharges(entry, exit);

            //then
            Assert.IsInstanceOfType(result, typeof(IParkingReceipt));
            Assert.IsTrue(result.RateType == RateType.STANDARD);
        }
    }
}