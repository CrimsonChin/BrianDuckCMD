using System.Collections.Generic;
using BrainFuck.Instructions;

namespace BrainFuck
{
    internal class ProcessorContext
    {
        public ProcessorContext()
        {
            LoopIndexTracker = new Stack<int>();
        }

        public int PointerIndex { get; set; }
        public int InstructionIndex { get; set; }
        public Stack<int> LoopIndexTracker { get; }
        public List<IInstruction> Instructions { get; set; }

        public string Output { get; set; }
    }
}