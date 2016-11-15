namespace BrainFuck.Instructions
{
    internal class Output : IInstruction
    {
        void IInstruction.Execute(ProcessorContext processorContext, Cell[] cells)
        {
            var cell = cells[processorContext.PointerIndex];
            char? convertedCharacter = ConvertIntToChar(cell.ByteCount);
            if (convertedCharacter != null)
            {
                processorContext.Output += convertedCharacter;
            }                
        }

        private char? ConvertIntToChar(int value)
        {
            char? character = null;

            if (value >= 0 && value < 128)
            {
                character = (char) value;
            }

            return character;
        }
    }
}