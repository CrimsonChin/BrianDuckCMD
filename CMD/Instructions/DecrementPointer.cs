using System.Diagnostics;

namespace CMD.Instructions
{
    internal class DecrementPointer : IInstruction
    {
        public void Execute(ProcessorContext processorContext, BrianDuck brianDuck, Cell[] cells)
        {
            processorContext.PointerIndex--;
            Debug.WriteLine("Move Pointer Left: New Pointer: {0}", processorContext.PointerIndex);
        }
    }
}