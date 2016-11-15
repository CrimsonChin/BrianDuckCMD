using System;
using System.Collections.Generic;
using System.Diagnostics;
using BrainFuck.Instructions;

namespace BrainFuck
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new ProcessorContext();
            Cell[] cells =
            {
                new Cell(),
                new Cell(),
                new Cell(),
                new Cell(),
                new Cell(),
                new Cell(),
                new Cell()
            };

            Draw(context, cells);

            Console.WriteLine("Enter BrainF*ck Code");
            var userInstructions = Console.ReadLine();

            var instructions = ParseInstructions(userInstructions);
            context.Instructions = instructions;

            while (context.InstructionIndex < instructions.Count)
            {
                instructions[context.InstructionIndex].Execute(context, cells);
                Draw(context, cells);
                context.InstructionIndex++;
            }

            Console.ReadKey();
        }

        private static List<IInstruction> ParseInstructions(string code)
        {
            var instructions = new List<IInstruction>();
            foreach (var character in code.ToCharArray())
            {
                var instuction = GetInstruction(character);
                instructions.Add(instuction);
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
                default:
                    Debug.WriteLine("Unknown character.  Instruction Ignored.");
                    break;
            }

            return null;
        }

        private static void Draw(ProcessorContext processorContext, IReadOnlyList<Cell> cells)
        {
            var pointer = string.Empty;
            var byteCount = string.Empty;

            for (var index = 0; index < cells.Count; index++)
            {
                var cell = cells[index];
                byteCount += (cell.ByteCount.ToString("D3")) + " | ";
                pointer += (processorContext.PointerIndex == index ? " ^ " : "   ") + " | ";
            }

            Console.WriteLine("BYTES  : " + byteCount);
            Console.WriteLine("POINTER: " + pointer);
            Console.WriteLine("OUTPUT : " + processorContext.Output);
            Console.WriteLine();
        }
    }
}
