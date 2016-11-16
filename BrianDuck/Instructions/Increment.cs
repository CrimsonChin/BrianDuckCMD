using System;

namespace BrianDuck
{
    internal class Increment : IInstruction
    {
        public void Execute(BrianDuck brianDuck, Workbench[] gameboard)
        {
            Console.WriteLine(nameof(Increment));

            if (brianDuck.CarriedItem != Material.None)
            {
                Console.WriteLine("Brian is already holding something.  He cannot pickup");
                return;
            }

            var workbench = gameboard[brianDuck.Index];
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