using System.Diagnostics;
using System.Linq;

namespace CMD.Instructions
{
    internal class EndLoop : IInstruction
    {
        public void Execute(ProcessorContext processorContext, BrianDuck brianDuck, Cell[] cells)
        {
            Debug.WriteLine("End of Loop");
            if (processorContext.LoopIndexTracker.Any())
            {
                var programIndex = processorContext.LoopIndexTracker.Pop();
                processorContext.InstructionIndex = programIndex;
            }
            else
            {
                Debug.WriteLine("Error");
            }
        }
    }
}