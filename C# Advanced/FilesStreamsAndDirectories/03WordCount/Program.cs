using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace _03WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = File.ReadAllLines("words.txt");
            var text = File.ReadAllText("text.txt").ToLower().Split(" ,-!?.".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var wordsCount = new Dictionary<string, int>();
            var sb = new StringBuilder();

            foreach (var word in words)
            {
                if (!wordsCount.ContainsKey(word))
                {
                    wordsCount[word] = 0;
                }
                foreach (var item in text)
                {
                    if (word == item)
                    {
                        wordsCount[word]++;
                    }
                }
            }

            foreach (var word in wordsCount.OrderByDescending(x=>x.Value))
            {
                sb.AppendLine($"{word.Key} - {word.Value}");
            }

            File.WriteAllText("actualResults.txt", sb.ToString());

            var areResultLikeExpected = File.ReadLines("actualResults.txt").SequenceEqual(File.ReadLines("expectedResult.txt"));

            Console.WriteLine(areResultLikeExpected);
        }
    }
}
