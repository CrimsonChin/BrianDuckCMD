using System;

namespace BrianDuck
{
    internal class Assembler : IInstruction
    {
        public void Execute(BrianDuck brianDuck, Workbench[] gameboard)
        {
            Workbench workbench = gameboard[brianDuck.Index];
            if (workbench.LegCount == 4 && workbench.TopCount == 1)
            {
                workbench.TableCount += 1;
                workbench.LegCount -= 4;
                workbench.TopCount -= 1;

                Console.WriteLine("Table Built!");
            }
            else
            {
                Console.WriteLine("Wrong number of stuffs.  Maybe too much, maybe too little.");
            }
        }
    }
}