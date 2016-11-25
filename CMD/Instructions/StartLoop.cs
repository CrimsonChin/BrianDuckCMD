using System.Collections.Generic;
using System.Diagnostics;

namespace CMD.Instructions
{
    internal class StartLoop : IInstruction
    {
        public void Execute(ProcessorContext processorContext, BrianDuck brianDuck, Cell[] cells)
        {
            Debug.WriteLine("Start Loop");
            var cell = cells[processorContext.PointerIndex];

            if (cell.ByteCount == 0)
            {
                var track = new Stack<int>();

                for (var instructionIndex = processorContext.InstructionIndex;
                    instructionIndex < processorContext.Instructions.Count;
                    instructionIndex++)
                {
                    var instruction = processorContext.Instructions[instructionIndex];
                    var instructionType = instruction.GetType();
                    if (instructionType == typeof(StartLoop))
                    {
                        track.Push(instructionIndex);
                    }
                    else if (instructionType == typeof(EndLoop))
                    {
                        track.Pop();
                    }

                    if (track.Count == 0)
                    {
                        Debug.WriteLine("Closing Brace Index: " + instructionIndex);
                        processorContext.InstructionIndex = instructionIndex;
                        break;
                    }
                }
            }
            else
            {
                // Decrease index beacuse the instruction processor will increase the program index. Better to double check the StartLoop.
                processorContext.LoopIndexTracker.Push(processorContext.InstructionIndex - 1);
            }
        }
    }
}