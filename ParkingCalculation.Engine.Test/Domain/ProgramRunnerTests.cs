using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParkingCalculation.Engine.Config;
using ParkingCalculation.Engine.Domain;
using ParkingCalculation.Engine.Handler;
using ParkingCalculation.Engine.Model;
using System;

namespace ParkingCalculation.Engine.Domain.Tests
{
    [TestClass()]
    public class ProgramRunnerTests
    {
        [TestMethod()]
        public void ProgramRunnerGenerateTest_on_valid_input_times_generate_correct_parking_charges()
        {
            //given
            DateTime entry = new DateTime(2018,2,19,9,20,00), exit = new DateTime(2018, 2, 19, 19, 50, 00);
            var moqParkingCalculationEngineManager = new Mock<IParkingCalculationEngineManager>();
            moqParkingCalculationEngineManager.Setup(m => m.GenerateParkingCharge(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(new ParkingReceipt { });
            var sut = new ProgramRunner(moqParkingCalculationEngineManager.Object);

            //when
            var result = sut.Generate(entry.ToString("d/M/yyyy H:m"), exit.ToString("d/M/yyyy H:m"));

            //then
            Assert.IsInstanceOfType(result, typeof(IParkingReceipt));
            moqParkingCalculationEngineManager.Verify(v => v.GenerateParkingCharge(It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Once);
        }
        [TestMethod()]
        public void ProgramRunnerGenerateTest_on_invalid_input_times_generate_err_message()
        {
            //given
            DateTime entry = DateTime.MinValue, exit = new DateTime(2018, 2, 19, 19, 50, 00);
            var moqParkingCalculationEngineManager = new Mock<IParkingCalculationEngineManager>();
            moqParkingCalculationEngineManager.Setup(m => m.GenerateParkingCharge(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(new ParkingReceipt { });
            var sut = new ProgramRunner(moqParkingCalculationEngineManager.Object);

            //when
            var result = sut.Generate(entry.ToString("d/M/yyyy H:m"), exit.ToString("d/M/yyyy H:m"));

            //then
            Assert.IsInstanceOfType(result, typeof(IParkingReceipt));
            Assert.IsTrue(result.Erred);
            moqParkingCalculationEngineManager.Verify(v => v.GenerateParkingCharge(It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Never);
        }
        [TestMethod()]
        public void IntegrationTest_valid_inputs_returns_price_and_parking_type_name()
        {
            //given
            var inDaysBefore = new Random().Next(50, 100); var outDaysBefore = new Random().Next(40, 50);
            DateTime inDateTime = DateTime.Now.AddHours(-inDaysBefore);
            DateTime outDateTime = DateTime.Now.AddHours(-outDaysBefore);
            var IProgramRunner = UnityConfig.GetProgramRunner();
            
            //when
            var result = IProgramRunner.Generate(inDateTime.ToString("d/M/yyyy H:m"), outDateTime.ToString("d/M/yyyy H:m"));

            //then
            Assert.IsInstanceOfType(result, typeof(IParkingReceipt));
        }

        [TestMethod()]
        public void ParkingCalculationEngineManagerGenerateParkingChargeTest_valid_inputs_returns_price_and_parking_type_name()
        {
            //given
            DateTime entry = new DateTime(2018,2,19,9,20,00), exit = new DateTime(2018, 2, 19, 19, 50, 00);
            var moqParkingRateHandlerSetting = new Mock<IParkingRateHandlersSetting>();
            var niteHandler = new Mock<ParkingRateHandler>();
            var ebHandler = new EarlyBirdRateHandler();
            ebHandler.SetNextHandler(niteHandler.Object);
            moqParkingRateHandlerSetting.Setup(m => m.Set).Returns(ebHandler);
            var sut = new ParkingCalculationEngineManager(moqParkingRateHandlerSetting.Object);
            
            //when
            var result = sut.GenerateParkingCharge(entry, exit);


            //then
            Assert.IsInstanceOfType(result, typeof(IParkingReceipt));
            Assert.IsTrue(result.RateType == RateType.EARLY);
        }
    }
}