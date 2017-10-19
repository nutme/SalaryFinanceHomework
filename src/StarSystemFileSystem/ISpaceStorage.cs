using SalaryFinanceHomework.StarSystemCore;
using System.Collections.Generic;

namespace SalaryFinanceHomework.StarSystemFileSystem
{
    public interface ISpaceStorage
    {
        string SaveSpace(IEnumerable<ISpaceObject> spaceArray);
        IEnumerable<ISpaceObject> LoadSpace(string fileName);
    }
}
