using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassBoxData
{
    class Program
    {
        static void Main()
        {
            try
            {
                var length = double.Parse(Console.ReadLine());
                var width = double.Parse(Console.ReadLine());
                var height = double.Parse(Console.ReadLine());
                var box = new Box(length, width, height);
                Console.WriteLine("Surface Area - {0:f2}", box.GetSurfaceArea());
                Console.WriteLine("Lateral Surface Area - {0:f2}", box.GetLateralArea());
                Console.WriteLine("Volume - {0:f2}", box.GetVolume());
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
