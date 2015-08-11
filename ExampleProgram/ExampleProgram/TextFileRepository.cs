using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProgram
{
    public interface ITextFileRepository
    {
        string[] GetFileLines(string fileName);
    }

    public class TextFileRepository : ITextFileRepository
    {
        public string[] GetFileLines(string fileName)
        {
            return File.ReadAllLines(fileName);
        }
    }
}
