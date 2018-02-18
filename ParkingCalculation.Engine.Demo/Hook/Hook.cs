using System;
using System.Globalization;
using ParkingCalculation.Engine.Config;
using ParkingCalculation.Engine.Model;

namespace ParkingCalculation.Demo
{
    static class Hook
    {
        static IParkingReceipt parkingReceipt; static string inTime = string.Empty, outTime = string.Empty;
        internal static void Generate()
        {
            ReadIt();
            HookIt();
            RunIt();
        }
        static void ReadIt()
        {
            Console.WriteLine($"Enter entry date: dd/mm/yyyy HH:mm"); inTime = Console.ReadLine();
            Console.WriteLine($"Enter exit date: dd/mm/yyyy HH:mm"); outTime = Console.ReadLine();
        }
        static void HookIt()
        {
            var emp = UnityConfig.GetProgramRunner();
            parkingReceipt = emp.Generate(inTime, outTime);
            while (parkingReceipt.Erred){
                Console.WriteLine("You have entered an incorrect date(s)/format. Try Again!");
                ReadIt();
            }
        }
        static void RunIt()
        {
            Console.WriteLine($"Parking rate name:{parkingReceipt.ParkingName}::Charges = ${parkingReceipt.ParkingPrice}");
            Console.WriteLine($"################################################");
        }
    }
}
