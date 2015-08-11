using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProgram
{
    /// <summary>
    /// Requirements:
    /// 
    /// 1.1. User can enter a single number
    /// 1.2. User is shown the number with all its digits reversed
    /// 1.3. User can only enter positive integer numbers
    /// 1.4. Incorrect inputs are communicated to the user
    /// 
    /// 2.1. User can supply a list of numbers in a text file (line separated)
    /// 2.2. User is shown all the numbers with their digits reversed
    /// 2.3. User can only supply positive integer numbers in the file
    /// 2.4. Incorrect inputs are communicated to the user
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var numberJumbler = new NumberJumbler(new TextFileRepository());

            // Single input
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter a positive integer number");
                string input = Console.ReadLine();
                Console.WriteLine(String.Format("Your new number is {0}", numberJumbler.Jumble(input)));
                Environment.Exit(0);
            }

            // Bulk input
            Console.WriteLine("Your new numbers are:");
            foreach (string number in numberJumbler.BulkJumble(args[0]))
            {
                Console.WriteLine(number);
            }
        }
    }
}
