using NUnit.Framework;
using SalaryFinanceHomework.StarSystemGenerator.Worker;

namespace SalaryFinanceHomework.StarSystemGenerator.Tests
{
    /// <summary>
    /// This test creates big amoung of random data
    /// However it's possible once in timespace continium to get two identical results
    /// </summary>
    [TestFixture]
    public class CryptoRandomnessProviderTests
    {
        [Test]
        public void TwoRunsToCreateRandomArraysWillBeDiferent()
        {
            var numberOfRuns = 10000;
            var randomnessProvider = new CryptoRandomnessProvider();

            var array1 = new int[numberOfRuns];
            var array2 = new int[numberOfRuns];

            for (int index = 0; index < numberOfRuns; index++)
            {
                array1[index] = randomnessProvider.GetRandomInt(10);
                array2[index] = randomnessProvider.GetRandomInt(10);
            }

            Assert.That(array1, Is.Not.EqualTo(array2));
        }
    }
}
