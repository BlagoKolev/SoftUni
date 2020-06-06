using System;
using System.IO;
using System.Text;

namespace _01.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {

            using var reader = new StreamReader("text.txt");
            var count = 0;

            while (true)
            {
                var line = reader.ReadLine();

                if (line == null)
                {
                    break;
                }

                if (count % 2 == 0)
                {
                    var lineAsArray = line.Split();
                    Array.Reverse(lineAsArray);

                    for (int i = 0; i < lineAsArray.Length; i++)
                    {
                        var currentWord = lineAsArray[i];
                        for (int j = 0; j < currentWord.Length; j++)
                        {
                            var symbol = currentWord[j];

                            if (symbol == '.' || symbol == ',' || symbol == '-' || symbol == '!' || symbol == '?')
                            {
                                currentWord = currentWord.Replace(symbol, '@');
                                lineAsArray[i] = currentWord;
                            }
                        }

                    }
                   
                    Console.WriteLine(string.Join(" ", lineAsArray));
                }
                count++;
            }

        }
    }
}
