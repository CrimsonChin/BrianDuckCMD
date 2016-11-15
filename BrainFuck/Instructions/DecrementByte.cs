using System.Diagnostics;

namespace BrainFuck.Instructions
{
    internal class DecrementByte : IInstruction
    {
        void IInstruction.Execute(ProcessorContext processorContext, Cell[] cells)
        {
            var workbench = cells[processorContext.PointerIndex];
            workbench.ByteCount--;
            Debug.WriteLine("Decrease ByteCount.  Pointer: {0} ByteCount: {1}", processorContext.PointerIndex,
                workbench.ByteCount);
        }
    }
}