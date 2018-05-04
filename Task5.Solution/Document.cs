using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Solution.Api;

namespace Task5.Solution
{
    public class Document : IDocument
    {
        private List<IConverter> parts;

        public Document(IEnumerable<IConverter> parts)
        {
            if (parts == null)
            {
                throw new ArgumentNullException(nameof(parts));
            }

            this.parts = new List<IConverter>(parts);
        }

        public string GetBody()
        {
            string output = string.Empty;

            foreach (DocumentPart part in this.parts)
            {
                output += $"{part.Convert()}\n";
            }

            return output;
        }
    }
}
