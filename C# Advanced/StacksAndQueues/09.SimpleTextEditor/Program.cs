using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var blank = string.Empty;
            var text = new Stack<string>();
            text.Push(blank);

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var command = int.Parse(input[0]);

                if (command == 1)
                {
                    var newText = input[1];
                    var oldText = text.Peek();
                    var textToAdd = string.Concat(oldText + newText);
                    text.Push(textToAdd);
                }

                else if (command == 2)
                {
                    var count = int.Parse(input[1]);
                    var textToEdit = text.Peek();
                    var startIndex = textToEdit.Length - count;
                    var editedText = textToEdit.Remove(startIndex, count);
                    text.Push(editedText);
                }

                else if (command == 3)
                {
                    var index = int.Parse(input[1]) - 1;
                    var textToCheck = text.Peek();
                    var symbol = textToCheck[index];
                    Console.WriteLine(symbol);

                }

                else if (command == 4)
                {
                    text.Pop();
                }
            }
        }
    }
}
