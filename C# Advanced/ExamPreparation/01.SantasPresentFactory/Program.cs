using System;
using System.Collections.Generic;
using System.Linq;

namespace SantasPresentFactory
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var boxOfMaterials = ReadInput(Console.ReadLine());
            var magicNumbers = ReadInput(Console.ReadLine());

            var boxStack = new Stack<int>(boxOfMaterials);
            var magicQueue = new Queue<int>(magicNumbers);
            var craftedPresents = new Dictionary<string, int>();

            var dollCrafted = false;
            var woodenTrainCrafted = false;
            var teddyBearCrafted = false;
            var bicycleCrafted = false;

            while (boxStack.Any() && magicQueue.Any())
            {
                var box = boxStack.Peek();
                var magic = magicQueue.Peek();

                if (box == 0 || magic == 0)
                {
                    if (box == 0)
                    {
                        boxStack.Pop();
                    }

                    if (magic == 0)
                    {
                        magicQueue.Dequeue();
                    }
                    continue;
                }
                    var multiply = box * magic;

                    if (multiply < 0)
                    {
                        var result = box + magic;
                        boxStack.Pop();
                        magicQueue.Dequeue();
                        boxStack.Push(result);
                        continue;
                    }
                    else
                    {
                        if (multiply == 150)
                        {
                            dollCrafted = true;
                            if (!craftedPresents.ContainsKey("Doll"))
                            {
                                craftedPresents["Doll"] = 0;
                            }
                            craftedPresents["Doll"]++;
                        }
                        else if (multiply == 250)
                        {
                            woodenTrainCrafted = true;
                            if (!craftedPresents.ContainsKey("Wooden train"))
                            {
                                craftedPresents["Wooden train"] = 0;
                            }
                            craftedPresents["Wooden train"]++;
                        }
                        else if (multiply == 300)
                        {
                            teddyBearCrafted = true;
                            if (!craftedPresents.ContainsKey("Teddy bear"))
                            {
                                craftedPresents["Teddy bear"] = 0;
                            }
                            craftedPresents["Teddy bear"]++;
                        }
                        else if (multiply == 400)
                        {
                            bicycleCrafted = true;
                            if (!craftedPresents.ContainsKey("Bicycle"))
                            {
                                craftedPresents["Bicycle"] = 0;
                            }
                            craftedPresents["Bicycle"]++;
                        }
                        else
                        {
                            magicQueue.Dequeue();
                            box = boxStack.Pop();
                            box += 15;
                            boxStack.Push(box);
                            continue;
                        }
                        boxStack.Pop();
                        magicQueue.Dequeue();
                        continue;
                    }


                }

                if ((dollCrafted && woodenTrainCrafted) || (teddyBearCrafted && bicycleCrafted))
                {
                    Console.WriteLine("The presents are crafted! Merry Christmas!");
                }
                else
                {
                    Console.WriteLine("No presents this Christmas!");
                }

                if (boxStack.Any())
                {
                    Console.WriteLine("Materials left: " + string.Join(", ", boxStack));
                }
                if (magicQueue.Any())
                {
                    Console.WriteLine("Magic left: " + string.Join(", ", magicQueue));
                }

                foreach (var present in craftedPresents.OrderBy(x => x.Key))
                {
                    Console.WriteLine("{0}: {1}", present.Key, present.Value);
                }

            }
            public static int[] ReadInput(string input)
            {
                return input.Split().Select(int.Parse).ToArray();
            }
        }
    }
