using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CMD.Instructions;

namespace CMD
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var isExecuting = true;
            while (isExecuting)
            {
                DrawBryanDuckQuote("Bryan Duck; Table Maker Extraordinaire");

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
                    new Cell(true)
                };

                DrawGameBoard(context, brian, cells);

                Console.WriteLine("You have one attempt to build as many tables as possible.");
                Console.WriteLine("Enter BrianDuck code:");

                var userInstructions = Console.ReadLine();

                var instructions = ParseInstructions(userInstructions);
                context.Instructions = instructions;
                context.InstructionIndex = 0;

                while (context.InstructionIndex < instructions.Count)
                {
                    instructions[context.InstructionIndex].Execute(context, brian, cells);
                    DrawGameBoard(context, brian, cells);
                    context.InstructionIndex++;
                }

                var lastBench = cells.SingleOrDefault(x => x.IsFinal);
                if (lastBench != null)
                {
                    var tableScore = lastBench.TableCount*15;
                    Console.WriteLine("Tables Ready For Sale: " + lastBench.TableCount);
                    Console.WriteLine($"Table Score: { tableScore }. Code Length: {instructions.Count}.  Final Score { tableScore - instructions.Count }");

                    IList<string> motivationQuotes;
                    if (lastBench.TableCount > 0)
                    {
                        motivationQuotes = new List<string>
                        {
                            "WOW! Business is looking good today",
                            "I'm excited for the future",
                            "Top Banana? Ha! Top duck more like!",
                            "The Kids will be proud of me today",
                            "I'm going to be rich",
                            $"{lastBench.TableCount} Tables! A-MAY-ZING",
                            "I might be the cleverest duck in the world",
                            "Putting the DUCK in Producktive",
                            "Cool beans! TABLES!"
                        };
                    }
                    else
                    {
                        motivationQuotes = new List<string>
                        {
                            "Not a single table.  I'm in trouble.",
                            "Woah my work was poor today.",
                            "Where did I put the rope?",
                            "I-I-I I'm so embarrassed"
                        };
                    }

                    var random = new Random();
                    var randomIndex = random.Next(0, motivationQuotes.Count);
                    var text = motivationQuotes[randomIndex];
                    DrawBryanDuckQuote(text);


                    Console.WriteLine("Press 'e' to exit or hit return to go again");

                    userInstructions = Console.ReadLine();

                    if (!string.IsNullOrEmpty(userInstructions) && userInstructions.Equals("e"))
                    {
                        isExecuting = false;
                    }
                    else
                    {
                        Console.Clear();
                    }
                }
            }
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

        private static void DrawBryanDuckQuote(string quote)
        {
            Console.WriteLine($@"         {new string('_', quote.Length + 2)} ");
            Console.WriteLine($@"   _    |{new string(' ', quote.Length + 2)}| ");
            Console.WriteLine($@"__(.)= <  {quote} |");
            Console.WriteLine($@"\___)   |{new string('_', quote.Length + 2)}|");
            Console.WriteLine();
        }

        private static void DrawGameBoard(ProcessorContext processorContext, BrianDuck brianDuck, IReadOnlyList<Cell> cells)
        {
            var endMarker = string.Empty;
            var table = string.Empty;
            var tops = string.Empty;
            var legs = string.Empty;
            var bryanDuck = string.Empty;
            var breadCount = string.Empty;

            for (var index = 0; index < cells.Count; index++)
            {
                var workbench = cells[index];
                table += workbench.TableCount.ToString("D3") + " | ";
                tops += workbench.TopCount.ToString("D3") + " | ";
                legs += workbench.LegCount.ToString("D3") + " | ";
                endMarker += workbench.IsFinal ? "END" : "      ";

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

                breadCount += workbench.ByteCount.ToString("D3") + " | ";
                bryanDuck += (processorContext.PointerIndex == index ? $" {item} " : "   ") + " | ";
            }

            Console.WriteLine("         " + endMarker);
            Console.WriteLine("TABLE  : " + table);
            Console.WriteLine("TOPS   : " + tops);
            Console.WriteLine("LEGS   : " + legs);
            Console.WriteLine("BREAD  : " + breadCount);
            Console.WriteLine("BRIAN  : " + bryanDuck);

            Console.WriteLine();
        }
    }
}