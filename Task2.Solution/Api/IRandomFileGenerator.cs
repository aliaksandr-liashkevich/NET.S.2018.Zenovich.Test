using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Solution.Api
{
    public interface IRandomFileGenerator
    {
        string WorkingDirectory { get; set; }

        string FileExtension { get; }

        void GenerateFiles(int filesCount, int contentLength);
    }
}
