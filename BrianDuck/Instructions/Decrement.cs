using System;

namespace BrianDuck
{
    internal class Decrement : IInstruction
    {
        public void Execute(BrianDuck brianDuck, Workbench[] gameboard)
        {
            Console.WriteLine(nameof(Decrement));

            if (brianDuck.CarriedItem == Material.None)
            {
                Console.WriteLine("Brian isn't holding anything!");
                return;
            }

            var workbench = gameboard[brianDuck.Index];
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