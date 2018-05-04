using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution.Api
{
    public abstract class DocumentPart : IConverter
    {
        public string Text { get; set; }

        public abstract string Convert();
    }
}
