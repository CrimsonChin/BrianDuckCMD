using System.Collections.Generic;
using CMD.Instructions;

namespace CMD
{
    internal class ProcessorContext
    {
        public ProcessorContext()
        {
            LoopIndexTracker = new Stack<int>();
        }

        public int PointerIndex { get; set; } // Should this be on Bryan?
        public int InstructionIndex { get; set; }
        public Stack<int> LoopIndexTracker { get; }
        public List<IInstruction> Instructions { get; set; }
        public string Output { get; set; }
    }
}