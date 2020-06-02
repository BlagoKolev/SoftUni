﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace FunctionalPrograming
{
    class Program
    {
        static void Main()
        {
          
            
            Action<string> print = x => Console.WriteLine(x);

          Console.ReadLine().Split().ToList().ForEach(print);

        }
       
    }
}