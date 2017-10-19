using SalaryFinanceHomework.StarSystemCore;
using System;
using System.Collections.Generic;
using System.IO;

namespace SalaryFinanceHomework.StarSystemFileSystem
{
    /// <summary>
    /// Class to save and load space on file system
    /// Data is stored in binary format inside of TXT file
    /// Binnery serialiazed files are much faster than plain text or XML
    /// 
    /// problem wth text based storage is parsing
    /// it adds complexity and is slow
    /// </summary>
    public class SpaceStorage : ISpaceStorage
    {
        public string SaveSpace(IEnumerable<ISpaceObject> spaceArray)
        {
            var fileName = $"space{DateTime.Now.Ticks}.txt";
            return SaveSpace(spaceArray, fileName);
        }

        public string SaveSpace(IEnumerable<ISpaceObject> spaceArray, string fileName)
        {
            using (var stream = File.Open(fileName, FileMode.Create))
            {
                var binaryfier = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryfier.Serialize(stream, spaceArray);
            }

            return fileName;
        }

        public IEnumerable<ISpaceObject> LoadSpace(string fileName)
        {
            using (var stream = File.Open(fileName, FileMode.Open))
            {
                var binaryfier = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                var spaceArray = (List<ISpaceObject>)binaryfier.Deserialize(stream);
                return spaceArray;
            }
        }
    }
}
