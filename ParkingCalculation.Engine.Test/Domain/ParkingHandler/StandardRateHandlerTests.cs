using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingCalculation.Engine.Model;
using System;

namespace ParkingCalculation.Engine.Handler.Tests
{
    [TestClass()]
    public class StandardRateHandlerTests
    {
        [TestInitialize]
        public void Init()
        {

        }
        [TestCleanup]
        public void CleanUp()
        {

        }
        [TestMethod()]
        public void StandardRateHandlerGetParkingChargesTest_Get_Correct_ParkingCharges()
        {
            //given
            var rndm = new Random();
            DateTime entry=DateTime.Now.AddHours(-rndm.Next(50, 100)),exit= DateTime.Now.AddHours(-rndm.Next(20));
            var sut = new StandardRateHandler();

            //when
            var result = sut.GetParkingCharges(entry, exit);

            //then
            Assert.IsInstanceOfType(result, typeof(IParkingReceipt));
            Assert.IsTrue(result.RateType == RateType.STANDARD);
        }
    }
}