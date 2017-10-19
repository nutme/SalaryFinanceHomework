namespace SalaryFinanceHomework.StarSystemNavigator.Worker
{
    public class ColonizationMeter
    {
        public int SpaceColonized { get; private set; }

        public ColonizationMeter()
        {
            SpaceColonized = 0;
        }

        public void AddSoace(int newSpace)
        {
            SpaceColonized += newSpace;
        }
    }
}
