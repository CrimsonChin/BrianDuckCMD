using System;

namespace BrianDuck
{
    internal class MoveRight : IInstruction
    {
        public void Execute(BrianDuck brianDuck, Workbench[] gameboard)
        {
            Console.WriteLine(nameof(MoveRight));
            brianDuck.Index++;
        }
    }
}