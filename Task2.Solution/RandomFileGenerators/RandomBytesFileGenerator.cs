using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Solution.Api;

namespace Task2.Solution.RandomFileGenerators
{
    class RandomBytesFileGenerator : IRandomFileGenerator
    {
        private string _workingDirectory;

        public RandomBytesFileGenerator()
        {
            FileExtension = ".bytes";
        }

        public string WorkingDirectory
        {
            get
            {
                if (_workingDirectory == null)
                {
                    throw new ArgumentNullException(nameof(WorkingDirectory));
                }

                return _workingDirectory;
            }
            set
            {
                _workingDirectory = value;
            }
        }

        public string FileExtension { get; protected set; }

        public void GenerateFiles(int filesCount, int contentLength)
        {
            for (var i = 0; i < filesCount; ++i)
            {
                var generatedFileContent = this.GenerateFileContent(contentLength);

                var generatedFileName = $"{Guid.NewGuid()}{this.FileExtension}";

                this.WriteBytesToFile(generatedFileName, generatedFileContent);
            }
        }

        private byte[] GenerateFileContent(int contentLength)
        {
            var random = new Random();

            var fileContent = new byte[contentLength];

            random.NextBytes(fileContent);

            return fileContent;
        }

        private void WriteBytesToFile(string fileName, byte[] content)
        {
            if (!Directory.Exists(WorkingDirectory))
            {
                Directory.CreateDirectory(WorkingDirectory);
            }

            File.WriteAllBytes($"{WorkingDirectory}//{fileName}", content);
        }
    }
}
