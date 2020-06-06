using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var lineNumber = 1;
            var result = new List<string>();

            var lines = File.ReadAllLines("text.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                var letters = 0;
                var punctoationMark = 0;
                var line = lines[i];

                for (int j = 0; j < line.Length; j++)
                {
                    if (char.IsLetter(line[j]))
                    {
                        letters++;
                    }
                    else if (char.IsPunctuation(line[j]))
                    {
                        punctoationMark++;
                    }
                }
                line = ($"Line{lineNumber}: {line} ({letters})({punctoationMark})");
                result.Add(line);
                Console.WriteLine(line);
                lineNumber++;
            }

            File.WriteAllLines("output.txt", result);

        }
    }
}
