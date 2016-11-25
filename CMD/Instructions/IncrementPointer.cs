using System.Diagnostics;

namespace CMD.Instructions
{
    internal class IncrementPointer : IInstruction
    { 
        public void Execute(ProcessorContext processorContext, BrianDuck brianDuck, Cell[] cells)
        {
            processorContext.PointerIndex++;
            Debug.WriteLine("Move Pointer Right: New Pointer: {0}", processorContext.PointerIndex);
        }
    }
}