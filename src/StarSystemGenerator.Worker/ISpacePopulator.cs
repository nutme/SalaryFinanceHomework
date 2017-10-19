using System.Collections.Generic;
using SalaryFinanceHomework.StarSystemCore;

namespace SalaryFinanceHomework.StarSystemGenerator.Worker
{
    public interface ISpacePopulator
    {
        IEnumerable<ISpaceObject> Run(int capacity);
    }
}
