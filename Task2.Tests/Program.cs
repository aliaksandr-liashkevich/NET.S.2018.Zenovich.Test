using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Solution.Api;
using Task2.Solution.RandomFileGenerators;

namespace Task2.Tests
{
    public static class Program
    {
        public static void Main()
        {
            IRandomFileGenerator bytesGenerator = new RandomBytesFileGenerator();
            bytesGenerator.WorkingDirectory = ".";

            IRandomFileGenerator charsGenerator = new RandomCharsFileGenerator();
            charsGenerator.WorkingDirectory = ".";

            bytesGenerator.GenerateFiles(2, 100);
            charsGenerator.GenerateFiles(4, 20);

            Console.ReadKey();
        }
    }
}
