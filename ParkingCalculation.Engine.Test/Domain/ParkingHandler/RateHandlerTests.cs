using ParkingCalculation.Engine.Handler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParkingCalculation.Engine.Model;
using System;

namespace ParkingCalculation.Engine.Handler.Tests
{
    [TestClass()]
    public class RateHandlerTests
    {
        Mock<ParkingRateHandler> moqParkingRateHandler;
        [TestInitialize]
        public void Init()
        {
            moqParkingRateHandler = new Mock<ParkingRateHandler>();
        }
        [TestCleanup]
        public void CleanUp()
        {
            moqParkingRateHandler = null;
        }
        [TestMethod()]
        public void EarlyBirdRateHandlerGetParkingChargesTest__Get_Correct_ParkingCharges()
        {
            //given
            DateTime entry = new DateTime(2018, 2, 19, 9, 20, 00), exit = new DateTime(2018, 2, 19, 19, 50, 00);
            var sut = new EarlyBirdRateHandler();
            sut.SetNextHandler(moqParkingRateHandler.Object);

            //when
            var result = sut.GetParkingCharges(entry, exit);

            //then
            Assert.IsInstanceOfType(result, typeof(IParkingReceipt));
            Assert.IsTrue(result.RateType == RateType.EARLY);
        }
        [TestMethod()]
        public void StandardRateHandlerGetParkingChargesTest_Get_Correct_ParkingCharges_for_more_than_24_hour()
        {
            //given
            var rndm = new Random();
            DateTime entry = DateTime.Now.AddHours(-rndm.Next(50, 100)), exit = DateTime.Now.AddHours(-rndm.Next(20));
            var sut = new StandardRateHandler();

            //when
            var result = sut.GetParkingCharges(entry, exit);

            //then
            Assert.IsInstanceOfType(result, typeof(IParkingReceipt));
            Assert.IsTrue(result.RateType == RateType.STANDARD);
        }

        [TestMethod()]
        public void StandardRateHandlerGetParkingChargesTest_Get_20_ParkingCharges_for_3_hour_to_24_hour()
        {
            //given
            var rndm = new Random();
            DateTime entry = DateTime.Now.AddHours(-rndm.Next(3, 24)), exit = DateTime.Now.AddHours(-rndm.Next(3));
            var sut = new StandardRateHandler();

            //when
            var result = sut.GetParkingCharges(entry, exit);

            //then
            Assert.AreEqual(result.ParkingPrice, 20);
        }
        [TestMethod()]
        public void StandardRateHandlerGetParkingChargesTest_Get_15_ParkingCharges_for_2_hour_to_3_hour()
        {
            //given
            var rndm = new Random();
            DateTime entry = DateTime.Now.AddHours(rndm.Next(3,4)), exit = DateTime.Now.AddHours(rndm.Next(6,7));
            var sut = new StandardRateHandler();

            //when
            var result = sut.GetParkingCharges(entry, exit);

            //then
            Assert.AreEqual(15,result.ParkingPrice);
        }
        [TestMethod()]
        public void StandardRateHandlerGetParkingChargesTest_Get_10_ParkingCharges_for_1_hour_to_2_hour()
        {
            //given
            var rndm = new Random();
            DateTime entry = DateTime.Now.AddHours(rndm.Next(3, 4)), exit = DateTime.Now.AddHours(rndm.Next(5, 6));
            var sut = new StandardRateHandler();

            //when
            var result = sut.GetParkingCharges(entry, exit);

            //then
            Assert.AreEqual(10, result.ParkingPrice);
        }
        [TestMethod()]
        public void StandardRateHandlerGetParkingChargesTest_Get_10_ParkingCharges_for_0_hour_to_1_hour()
        {
            //given
            var rndm = new Random();
            DateTime entry = DateTime.Now.AddHours(rndm.Next(3, 4)), exit = DateTime.Now.AddHours(rndm.Next(5, 6));
            var sut = new StandardRateHandler();

            //when
            var result = sut.GetParkingCharges(entry, exit);

            //then
            Assert.AreEqual(10, result.ParkingPrice);
        }
        [TestMethod()]
        public void WeekendRateHandlerGetParkingChargesTest_Get_Correct_ParkingCharges()
        {
            //given
            DateTime entry = new DateTime(2018, 2, 24, 9, 20, 00), exit = new DateTime(2018, 2, 25, 19, 50, 00);
            var sut = new WeekendRateHandler();
            sut.SetNextHandler(moqParkingRateHandler.Object);

            //when
            var result = sut.GetParkingCharges(entry, exit);

            //then
            Assert.IsInstanceOfType(result, typeof(IParkingReceipt));
            Assert.IsTrue(result.RateType == RateType.WEEKEND);
        }

        [TestMethod()]
        public void NiteRateHandlerGetParkingChargesTest()
        {
            //given
            DateTime entry = new DateTime(2018, 2, 23, 19, 20, 00), exit = new DateTime(2018, 2, 24, 5, 50, 00);
            var sut = new NiteRateHandler();
            sut.SetNextHandler(moqParkingRateHandler.Object);

            //when
            var result = sut.GetParkingCharges(entry, exit);

            //then
            Assert.IsInstanceOfType(result, typeof(IParkingReceipt));
            Assert.IsTrue(result.RateType == RateType.NITE);
        }
    }
}