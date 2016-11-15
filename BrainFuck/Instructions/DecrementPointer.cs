using System.Diagnostics;

namespace BrainFuck.Instructions
{
    internal class DecrementPointer : IInstruction
    {
        void IInstruction.Execute(ProcessorContext processorContext, Cell[] cells)
        {
            processorContext.PointerIndex--;
            Debug.WriteLine("Move Pointer Left: New Pointer: {0}", processorContext.PointerIndex);
        }
    }
}