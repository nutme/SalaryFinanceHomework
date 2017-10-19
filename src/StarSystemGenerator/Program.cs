using SalaryFinanceHomework.StarSystemCore;
using SalaryFinanceHomework.StarSystemFileSystem;
using SalaryFinanceHomework.StarSystemGenerator.Worker;
using System;

namespace SalaryFinanceHomework.StarSystemGenerator
{
    class Program
    {
        static int Main(string[] args)
        {
            // creating instance of random generator & space object generator
            Console.WriteLine("Generating planets from interspace void");
            var randomnessProvider = new CryptoRandomnessProvider();
            var spacePopulator = new SpacePopulator(randomnessProvider);

            // Generating all space objects in one go and writing to the file
            // is better than writing one by one as it gets generated.
            // Reason for it is that file system I/O operations are expensive 

            // run accuall space generation
            var randomSpace = spacePopulator.Run(SpaceRules.SpaceSystemCapacity);

            // write results to the file
            Console.WriteLine("Saving space to file store");
            var fileStore = new SpaceStorage();
            var fileName = fileStore.SaveSpace(randomSpace);

            Console.WriteLine($"Saved space to file ${fileName}");

            return 0;
        }
    }
}
