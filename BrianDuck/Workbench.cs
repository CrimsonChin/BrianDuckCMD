namespace BrianDuck
{
    internal class Workbench
    {
        public Workbench()
            : this(false)
        {
        }

        public Workbench(bool isFinal)
        {
            IsFinal = isFinal;
        }

        public bool IsFinal { get; set; }
        public int TableCount { get; set; }
        public int TopCount { get; set; }
        public int LegCount { get; set; }

        public bool IsEmpty => TableCount == 0 && TopCount == 0 && LegCount == 0;

        public Material PickUp()
        {
            if (LegCount > 0)
            {
                LegCount--;
                return Material.Leg;
            }

            if (TopCount > 0)
            {
                TopCount--;
                return Material.Top;
            }

            if (TableCount > 0)
            {
                TableCount--;
                return Material.Table;
            }

            return Material.None;
        }
    }
}