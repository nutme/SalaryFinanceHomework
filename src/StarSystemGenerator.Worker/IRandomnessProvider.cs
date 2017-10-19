namespace SalaryFinanceHomework.StarSystemGenerator.Worker
{
    public interface IRandomnessProvider
    {
        bool GetRandomBool();
        int GetRandomInt(int upperLimmit);
        int GetRandomInt(int lowerLimit, int upperLimmit);
    }
}
