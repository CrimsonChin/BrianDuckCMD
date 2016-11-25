using System;
using System.Collections.Generic;
using System.Diagnostics;
using CMD.Instructions;

namespace CMD
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(@"         ______________________________ ");
            Console.WriteLine(@"   _    |                              |");
            Console.WriteLine(@"__(.)= <   Brian Duck; Table Maker!    |");
            Console.WriteLine(@"\___)   |______________________________|");
            Console.WriteLine();

            var brian = new BrianDuck();
            var context = new ProcessorContext();
            Cell[] cells =
            {
                new Cell
                {
                    TableCount = 1,
                    TopCount = 2
                },
                new Cell
                {
                    TableCount = 1,
                    LegCount = 9
                },
                new Cell(),
                new Cell(),
                new Cell(),
                new Cell(),
                new Cell(true)
            };

            Draw(context, brian, cells);

            //++++++++++[>+++++++>++++++++++>+++>+<<<<-]>++.>+.+++++++..+++.>++.<<+++++++++++++++.>.+++.------.--------.>+.>.

            var isExecuting = true;
            while (isExecuting)
            {
                Console.WriteLine("Enter BrainF*ck Code");
                var userInstructions = Console.ReadLine();

                if (!userInstructions.Equals("exit"))
                {
                    var instructions = ParseInstructions(userInstructions);
                    context.Instructions = instructions;
                    context.InstructionIndex = 0;

                    while (context.InstructionIndex < instructions.Count)
                    {
                        instructions[context.InstructionIndex].Execute(context, brian, cells);
                        Draw(context, brian, cells);
                        context.InstructionIndex++;
                    }
                }
                else
                {
                    isExecuting = false;
                }
            }


            Console.ReadKey();
        }

        private static List<IInstruction> ParseInstructions(string code)
        {
            var instructions = new List<IInstruction>();
            foreach (var character in code.ToCharArray())
            {
                var instuction = GetInstruction(character);
                if (instuction != null)
                {
                    instructions.Add(instuction);
                }
            }
            return instructions;
        }

        private static IInstruction GetInstruction(char character)
        {
            switch (character)
            {
                case '>':
                    return new IncrementPointer();
                case '<':
                    return new DecrementPointer();
                case '+':
                    return new IncrementByte();
                case '-':
                    return new DecrementByte();
                case '[':
                    return new StartLoop();
                case ']':
                    return new EndLoop();
                case '.':
                    return new Output();
                case ',':
                    return new Input();
                case '!':
                    return new BuildTableInstruction();
                default:
                    Debug.WriteLine("Unknown character.  Instruction Ignored.");
                    break;
            }

            return null;
        }

        private static void Draw(ProcessorContext processorContext, BrianDuck brianDuck, IReadOnlyList<Cell> cells)
        {
            var table = string.Empty;
            var tops = string.Empty;
            var legs = string.Empty;
            var carriedItem = string.Empty;

            var pointer = string.Empty;
            var byteCount = string.Empty;

            var benchesReadyForSale = 0;

            for (var index = 0; index < cells.Count; index++)
            {
                var workbench = cells[index];
                table += workbench.TableCount.ToString("D3") + " | ";
                ;
                tops += workbench.TopCount.ToString("D3") + " | ";
                ;
                legs += workbench.LegCount.ToString("D3") + " | ";
                ;

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
                    case Material.None:
                        item = "^";
                        break;
                    default:
                        item = " ";
                        break;
                }
                //carriedItem += $" {item} " + " | ";
                var cell = cells[index];
                byteCount += cell.ByteCount.ToString("D3") + " | ";
                pointer += (processorContext.PointerIndex == index ? $" {item} " : "   ") + " | ";


                if (workbench.IsFinal)
                {
                    benchesReadyForSale += workbench.TableCount;
                }
            }

            Console.WriteLine("TABLE  : " + table);
            Console.WriteLine("TOPS   : " + tops);
            Console.WriteLine("LEGS   : " + legs);
            Console.WriteLine("BREAD  : " + byteCount);
            Console.WriteLine("BRIAN  : " + pointer);
            Console.WriteLine("Benches Ready For Sale: " + benchesReadyForSale);

            List<string> motivationQuotes = new List<string>
            {
                "WOW! Business is looking good today",
                "I'm excited for the future",
                "Top Banana? Ha! Top duck more like!",
                "The Kids will be proud of me today",
                "I'm going to be rich",
                $"{benchesReadyForSale} Tables! A-MAY-ZING",
                "I might be the cleverest duck in the world",
                "Putting the DUCK in Producktive",
                "Cool beans! TABLES!"
            };

            if (benchesReadyForSale > 0)
            {
                Random r = new Random();
                var randomIndex = r.Next(0, motivationQuotes.Count);
                var text = motivationQuotes[randomIndex];
                //Console.WriteLine(@"         __________________________________ ");
                //Console.WriteLine(@"   _    |                                  |");
                //Console.WriteLine(@"__(.)= <  I can't build a table with this! |");
                //Console.WriteLine(@"\___)   |__________________________________|");

                Console.WriteLine($@"         {new string('_', text.Length + 2)} ");
                Console.WriteLine($@"   _    |{new string(' ', text.Length + 2)}| ");
                Console.WriteLine($@"__(.)= <  {text} |");
                Console.WriteLine($@"\___)   |{new string('_', text.Length + 2)}|");
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}