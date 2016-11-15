namespace BrainFuck.Instructions
{
    internal interface IInstruction
    {
        void Execute(ProcessorContext processorContext, Cell[] cells);
    }
}