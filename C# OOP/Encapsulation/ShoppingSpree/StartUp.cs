using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShoppingSpree.Core;

namespace ShoppingSpree
{
    class StartUp
    {
        static void Main(string[] args)
        {

            try
            {
                var engine = new Engine();
                engine.Run();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

    }
}
