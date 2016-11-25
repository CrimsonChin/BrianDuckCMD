using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Instructions
{
    internal class Input : IInstruction
    {
        public void Execute(ProcessorContext processorContext, BrianDuck brianDuck, Cell[] cells)
        {
            if (brianDuck.CarriedItem != Material.None)
            {
                Console.WriteLine("Brian is already holding something.  He cannot pickup");
                return;
            }

            var workbench = cells[processorContext.PointerIndex];
            if (workbench.IsEmpty)
            {
                Console.WriteLine("Nothing To PickUp");
                return;
            }

            var material = workbench.PickUp();
            brianDuck.CarriedItem = material;
        }
    }
}
