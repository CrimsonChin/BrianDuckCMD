using System.Diagnostics;

namespace CMD.Instructions
{
    internal class IncrementByte : IInstruction
    {
        public void Execute(ProcessorContext processorContext, BrianDuck brianDuck, Cell[] cells)
        {
            var cell = cells[processorContext.PointerIndex];
            cell.ByteCount++;
            Debug.WriteLine("Increase ByteCount.  Pointer: {0} ByteCount: {1}", processorContext.PointerIndex, cell.ByteCount);
        }
    }
}