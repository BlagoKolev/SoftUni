using System;

namespace ClassBox
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var lenght = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());

            try
            {
                var box = new Box(lenght, width, height);

                Console.WriteLine($"Surface Area - {box.GetSurfaceArea():f2}");
                Console.WriteLine($"Lateral Surface Area - {box.GetLateralArea():f2}");
                Console.WriteLine($"Volume - {box.GetVolume():f2}");
            }
            catch (InvalidOperationException message)
            {
                Console.WriteLine(message.Message);
               
            }
           
        }
    }
}
