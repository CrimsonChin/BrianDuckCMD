using System.Diagnostics;

namespace BrainFuck.Instructions
{
    internal class IncrementByte : IInstruction
    {
        void IInstruction.Execute(ProcessorContext processorContext, Cell[] cells)
        {
            var cell = cells[processorContext.PointerIndex];
            cell.ByteCount++;
            Debug.WriteLine("Increase ByteCount.  Pointer: {0} ByteCount: {1}", processorContext.PointerIndex,
                cell.ByteCount);
        }
    }
}