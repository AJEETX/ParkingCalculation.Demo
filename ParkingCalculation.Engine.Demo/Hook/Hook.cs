using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingCalculation.Engine;
using ParkingCalculation.Engine.Config;
using ParkingCalculation.Engine.Model;

namespace ParkingCalculation.Demo
{
    static class Hook
    {
        static string format = "d/M/yyyy H:m";static DateTime entryDateTime, exitDateTime; static string inTime = string.Empty, outTime = string.Empty;
        internal static void Generate()
        {
            ReadIt();
            HookIt();
            RunIt();
        }

        static void HookIt()
        {
             CultureInfo culture = CultureInfo.InvariantCulture; DateTimeStyles styles = DateTimeStyles.None;
            while (!(DateTime.TryParseExact(inTime, format, culture, styles, out entryDateTime)
                && DateTime.TryParseExact(outTime, format, culture, styles, out exitDateTime)
                ))
            {
                Console.WriteLine("You have entered an incorrect date(s)/format."); Console.WriteLine($"Try Again!");
                ReadIt();
            }
           
        }
        static void RunIt()
        {
            var emp = UnityConfig.GetProgramRunner();
            var parkingReceipt = emp.Generate(entryDateTime, exitDateTime);
            Console.WriteLine($"Name of parking rate: {parkingReceipt.ParkingName} :: Charges are:$ {parkingReceipt.ParkingPrice}");
            Console.WriteLine($"################################################");
        }
        static void ReadIt()
        {
            Console.WriteLine($"Enter entry date: {format}"); inTime = Console.ReadLine();
            Console.WriteLine($"Enter exit date:{format}"); outTime = Console.ReadLine();
        }
    }
}
