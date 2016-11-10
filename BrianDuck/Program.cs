using System;
using System.Collections.Generic;

namespace BrianDuck
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var brianDuck = new BrianDuck();
            Workbench[] gameboard =
            {
                new Workbench
                {
                    TableCount = 1,
                    TopCount = 2
                },
                new Workbench
                {
                    TableCount = 1,
                    LegCount = 9
                },
                new Workbench(), new Workbench(), new Workbench(true)
            };


            Draw(brianDuck, gameboard);

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Enter BrianDuck Code");
                var code = Console.ReadLine();

                isRunning = (code != "exit");

                var instructions = ProcessInstructions(code);

                foreach (var instruction in instructions)
                {
                    instruction.Execute(brianDuck, gameboard);
                    Draw(brianDuck, gameboard);
                    Console.WriteLine();
                }
            }


            //+>> -< +> -< +> -< +> -< +> -|
            Console.ReadKey();
        }

        private static List<IInstruction> ProcessInstructions(string code)
        {
            var instructions = new List<IInstruction>();
            foreach (var character in code.ToCharArray())
            {
                switch (character)
                {
                    case '>':
                        instructions.Add(new MoveRight());
                        break;
                    case '<':
                        instructions.Add(new MoveLeft());
                        break;
                    case '+':
                        instructions.Add(new Increment());
                        break;
                    case '-':
                        instructions.Add(new Decrement());
                        break;
                    case '[':
                        //instructions.Add(new StartLoop());
                        break;
                    case ']':
                        //instructions.Add(new EndLoop());
                        break;
                    case '!':
                        instructions.Add(new Assembly());
                        break;
                    default:
                        throw new Exception("Weird");
                }
            }
            return instructions;
        }

        private static void Draw(BrianDuck brianDuck, Workbench[] gameboard)
        {
            var table = " ";
            var tops = " ";
            var legs = " ";
            var brian = " ";
            var carriedItem = " ";

            var i = 0;
            foreach (var workbench in gameboard)
            {
                table += workbench.TableCount;
                tops += workbench.TopCount;
                legs += workbench.LegCount;

                brian += brianDuck.Index == i ? "^" : " ";

                string item;
                switch (brianDuck.CarriedItem)
                {
                    case Material.Table:
                        item = "X";
                        break;
                    case Material.Top:
                        item = "T";
                        break;
                    case Material.Leg:
                        item = "L";
                        break;
                    default:
                        item = " ";
                        break;
                }
                carriedItem += brianDuck.Index == i ? item : " ";
                i++;
            }
            Console.WriteLine("TABLE:" + table);
            Console.WriteLine("TOPS :" + tops);
            Console.WriteLine("LEGS :" + legs);
            Console.WriteLine("BRIAN:" + brian);
            Console.WriteLine("ITEM :" + carriedItem);

            var finalBench = gameboard[gameboard.Length - 1];
            if (finalBench.TableCount > 0)
            {
                Console.WriteLine("You have {0} table ready for sale!", finalBench.TableCount);
            }
        }

        private enum Material
        {
            None,
            Top,
            Leg,
            Table
        }

        private class Workbench
        {
            public Workbench()
                : this(false)
            {
            }

            public Workbench(bool isFinal)
            {
                IsFinal = isFinal;
            }

            public bool IsFinal { get; set; }
            public int TableCount { get; set; }
            public int TopCount { get; set; }
            public int LegCount { get; set; }

            public bool IsEmpty => TableCount == 0 && TopCount == 0 && LegCount == 0;

            public Material PickUp()
            {
                if (LegCount > 0)
                {
                    LegCount--;
                    return Material.Leg;
                }

                if (TopCount > 0)
                {
                    TopCount--;
                    return Material.Top;
                }

                if (TableCount > 0)
                {
                    TableCount--;
                    return Material.Table;
                }

                return Material.None;
            }
        }


        private class BrianDuck
        {
            public Material CarriedItem { get; set; }
            public int Index { get; set; }
        }

        private interface IInstruction
        {
            void Execute(BrianDuck brianDuck, Workbench[] gameboard);
        }

        private class MoveRight : IInstruction
        {
            public void Execute(BrianDuck brianDuck, Workbench[] gameboard)
            {
                Console.WriteLine(nameof(MoveRight));
                brianDuck.Index++;
            }
        }

        private class MoveLeft : IInstruction
        {
            public void Execute(BrianDuck brianDuck, Workbench[] gameboard)
            {
                Console.WriteLine(nameof(MoveLeft));
                brianDuck.Index--;
            }
        }


        private class Increment : IInstruction
        {
            public void Execute(BrianDuck brianDuck, Workbench[] gameboard)
            {
                Console.WriteLine(nameof(Increment));

                if (brianDuck.CarriedItem != Material.None)
                {
                    Console.WriteLine("Brian is already holding something.  He cannot pickup");
                    return;
                }

                var workbench = gameboard[brianDuck.Index];
                if (workbench.IsEmpty)
                {
                    Console.WriteLine("Nothing To PickUp");
                    return;
                }

                var material = workbench.PickUp();
                brianDuck.CarriedItem = material;
            }
        }

        private class Decrement : IInstruction
        {
            public void Execute(BrianDuck brianDuck, Workbench[] gameboard)
            {
                Console.WriteLine(nameof(Decrement));

                if (brianDuck.CarriedItem == Material.None)
                {
                    Console.WriteLine("Brian isn't holding anything!");
                    return;
                }

                var workbench = gameboard[brianDuck.Index];
                switch (brianDuck.CarriedItem)
                {
                    case Material.Leg:
                        workbench.LegCount++;
                        break;

                    case Material.Top:
                        workbench.TopCount++;
                        break;
                    case Material.Table:
                        workbench.TableCount++;
                        break;
                    case Material.None:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                brianDuck.CarriedItem = Material.None;
            }
        }

        private class Assembly : IInstruction
        {
            public void Execute(BrianDuck brianDuck, Workbench[] gameboard)
            {
                Workbench workbench = gameboard[brianDuck.Index];
                if (workbench.LegCount == 4 && workbench.TopCount == 1)
                {
                    workbench.TableCount += 1;
                    workbench.LegCount -= 4;
                    workbench.TopCount -= 1;

                    Console.WriteLine("Table Built!");
                }
                else
                {
                    Console.WriteLine("Wrong number of stuffs.  Maybe too much, maybe too little.");
                }
            }
        }

        private class StartLoop : IInstruction
        {
            public void Execute(BrianDuck brianDuck, Workbench[] gameboard)
            {
                Console.WriteLine(nameof(StartLoop));
            }
        }

        private class EndLoop : IInstruction
        {
            public void Execute(BrianDuck brianDuck, Workbench[] gameboard)
            {
                Console.WriteLine(nameof(EndLoop));
            }
        }
    }
}