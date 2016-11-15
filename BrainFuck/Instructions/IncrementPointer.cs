using System.Diagnostics;

namespace BrainFuck.Instructions
{
    internal class IncrementPointer : IInstruction
    {
        void IInstruction.Execute(ProcessorContext processorContext, Cell[] cells)
        {
            processorContext.PointerIndex++;
            Debug.WriteLine("Move Pointer Right: New Pointer: {0}", processorContext.PointerIndex);
        }
    }
}