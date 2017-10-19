using SalaryFinanceHomework.StarSystemCore;
using SalaryFinanceHomework.StarSystemFileSystem;
using System;
using System.Collections.Generic;

namespace SalaryFinanceHomework.StarSystemNavigator
{
    class Program
    {
        static int Main(string[] args)
        {
            var fileStore = new SpaceStorage();
            IEnumerable<ISpaceObject> spaceArray;

            // Try to load file provided
            try
            {
                var fileName = args[0];
                spaceArray = fileStore.LoadSpace(fileName);
            }
            catch(Exception ex)
            {
                throw new ArgumentException("File name is wrong or file can not be imported", ex);
            }



            Console.ReadKey();
            return 0;
        }
    }
}
