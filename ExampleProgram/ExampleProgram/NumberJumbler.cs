using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProgram
{
    public class NumberJumbler
    {
        private readonly ITextFileRepository _textFileRepository;

        public NumberJumbler(ITextFileRepository textFileRepository)
        {
            _textFileRepository = textFileRepository;
        }

        public string Jumble(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException();

            int number = 0;
            if (!int.TryParse(input, out number))
                throw new ArgumentException();

            return new String(input.Reverse().ToArray());
        }

        public IEnumerable<string> BulkJumble(string fileName)
        {
            List<string> newNumbers = new List<string>();
            string[] fileContents = _textFileRepository.GetFileLines(fileName);

            foreach (string line in fileContents)
                newNumbers.Add(Jumble(line));

            return newNumbers;
        }
    }
}
