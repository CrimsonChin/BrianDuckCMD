namespace BrianDuck
{
    internal interface IInstruction
    {
        void Execute(BrianDuck brianDuck, Workbench[] gameboard);
    }
}