using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Solution.Api;

namespace Task2.Solution.RandomFileGenerators
{
    public class RandomCharsFileGenerator : IRandomFileGenerator
    {
        private string _workingDirectory;

        public RandomCharsFileGenerator(string workingDirectory)
        {
            WorkingDirectory = workingDirectory;
            FileExtension = ".txt";
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
            var generatedString = this.RandomString(contentLength);

            var bytes = Encoding.Unicode.GetBytes(generatedString);

            return bytes;
        }

        private string RandomString(int Size)
        {
            var random = new Random();

            const string input = "abcdefghijklmnopqrstuvwxyz0123456789";

            var chars = Enumerable.Range(0, Size).Select(x => input[random.Next(0, input.Length)]);

            return new string(chars.ToArray());
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
