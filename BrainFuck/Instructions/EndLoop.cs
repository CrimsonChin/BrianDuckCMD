using System.Diagnostics;
using System.Linq;

namespace BrainFuck.Instructions
{
    internal class EndLoop : IInstruction
    {
        void IInstruction.Execute(ProcessorContext processorContext, Cell[] cells)
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