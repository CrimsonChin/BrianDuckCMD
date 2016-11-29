using System;

namespace CMD.Instructions
{
    internal class BuildTableInstruction : IInstruction
    {
        void IInstruction.Execute(ProcessorContext processorContext, BrianDuck brianDuck, Cell[] cells)
        {
            var workbench = cells[processorContext.PointerIndex];
            if (workbench.LegCount == 4 && workbench.TopCount == 1)
            {
                workbench.TableCount += 1;
                workbench.LegCount -= 4;
                workbench.TopCount -= 1;
            }
            else
            {
                Console.WriteLine("I can't build a table with this!");
            }
        }
    }
}