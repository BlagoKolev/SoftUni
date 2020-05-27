using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(new string[] { " -> " }
                    , StringSplitOptions
                    .RemoveEmptyEntries);

                var color = input[0];
                var clothes = input[1]
                    .Split(new char[] { ',' }
                    , StringSplitOptions
                    .RemoveEmptyEntries);

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }

                for (int j = 0; j < clothes.Length; j++)
                {
                    var currentDress = clothes[j];

                    if (!wardrobe[color].ContainsKey(currentDress))
                    {
                        wardrobe[color][currentDress] = 0;
                    }
                    wardrobe[color][currentDress] += 1;
                }


            }
            var wantedStuff = Console.ReadLine().Split();
            var wantedColor = wantedStuff[0];
            var wantedDress = wantedStuff[1];


            foreach (var color in wardrobe)
            {
                Console.WriteLine("{0} clothes:", color.Key);

                foreach (var clothes in color.Value)
                {
                    if (color.Key == wantedColor && clothes.Key == wantedDress)
                    {
                        Console.WriteLine("* {0} - {1} (found!)", clothes.Key, clothes.Value);
                    }
                    else
                    {
                        Console.WriteLine("* {0} - {1}", clothes.Key, clothes.Value);
                    }

                }
            }
        }
    }
}
