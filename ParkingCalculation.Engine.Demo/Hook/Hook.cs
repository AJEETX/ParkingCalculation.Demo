using System;
using System.Globalization;
using ParkingCalculation.Engine.Config;
using ParkingCalculation.Engine.Domain;
using ParkingCalculation.Engine.Model;

namespace ParkingCalculation.Demo
{
    static class Hook
    {
        static IParkingReceipt parkingReceipt; static string inTime = string.Empty, outTime = string.Empty;static IProgramRunner IProgramRunner;
        internal static void Generate()
        {
            GetProgramRunner();
            ReadIt();
            DisplayIt();
        }
        static void  GetProgramRunner()
        {
            IProgramRunner = UnityConfig.GetProgramRunner();
        }
        static void ReadIt()
        {
            Console.WriteLine($"Enter entry date: dd/mm/yyyy HH:mm"); inTime = Console.ReadLine();
            Console.WriteLine($"Enter exit date: dd/mm/yyyy HH:mm"); outTime = Console.ReadLine();
            parkingReceipt = IProgramRunner.Generate(inTime, outTime);
            if(parkingReceipt.Erred){
                Console.WriteLine("You have entered an incorrect date(s)/format. Try Again!");
                ReadIt();
            }
        }
        static void DisplayIt()
        {
            Console.WriteLine($"Parking rate name:{parkingReceipt.ParkingName}::Charges = ${parkingReceipt.ParkingPrice}");
            Console.WriteLine($"################################################");
        }
    }
}
