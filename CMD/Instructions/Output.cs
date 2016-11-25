using System;

namespace CMD.Instructions
{
    internal class Output : IInstruction
    { 
        public void Execute(ProcessorContext processorContext, BrianDuck brianDuck, Cell[] cells)
        {
            if (brianDuck.CarriedItem == Material.None)
            {
                Console.WriteLine("Brian isn't holding anything!");
                return;
            }

            var workbench = cells[processorContext.PointerIndex];
            switch (brianDuck.CarriedItem)
            {
                case Material.Leg:
                    workbench.LegCount++;
                    break;

                case Material.Top:
                    workbench.TopCount++;
                    break;
                case Material.Table:
                    workbench.TableCount++;
                    break;
                case Material.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            brianDuck.CarriedItem = Material.None;
        }
    }
}