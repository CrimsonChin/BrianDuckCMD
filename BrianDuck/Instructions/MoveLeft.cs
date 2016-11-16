using System;

namespace BrianDuck
{
    internal class MoveLeft : IInstruction
    {
        public void Execute(BrianDuck brianDuck, Workbench[] gameboard)
        {
            Console.WriteLine(nameof(MoveLeft));
            brianDuck.Index--;
        }
    }
}