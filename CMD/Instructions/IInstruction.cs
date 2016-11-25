namespace CMD.Instructions
{
    internal interface IInstruction
    {
        void Execute(ProcessorContext processorContext, BrianDuck brianDuck, Cell[] cells);
    }
}