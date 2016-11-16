using System;
using System.Collections.Generic;
using System.Diagnostics;

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
                    case '!':
                        instructions.Add(new Assembler());
                        break;
                    default:
                        Debug.WriteLine("Unknown character.  Instruction Ignored.");
                        break;
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
    }
}