using System;

namespace CMD.Instructions
{
    internal class BuildTableInstruction : IInstruction
    {
        public void Execute(ProcessorContext processorContext, BrianDuck brianDuck, Cell[] cells)
        {
            Cell workbench = cells[processorContext.PointerIndex];
            if (workbench.LegCount == 4 && workbench.TopCount == 1)
            {
                workbench.TableCount += 1;
                workbench.LegCount -= 4;
                workbench.TopCount -= 1;

                Console.WriteLine(@"         __________________________________ ");
                Console.WriteLine(@"   _    |                                  |");
                Console.WriteLine(@"__(.)= <  What a beautiful table!          |");
                Console.WriteLine(@"\___)   |__________________________________|");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(@"         __________________________________ ");
                Console.WriteLine(@"   _    |                                  |");
                Console.WriteLine(@"__(.)= <  I can't build a table with this! |");
                Console.WriteLine(@"\___)   |__________________________________|");
                Console.WriteLine();
            }
        }
    }
}