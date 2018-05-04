using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Solution.Api;
using Task5.Solution.Api.Converters;

namespace Task5.Solution.Factories
{
    public class LaTeXFactory : IFactory<ILaTeXConverter>
    {
        private List<ILaTeXConverter> converters = new List<ILaTeXConverter>();

        public void Add(ILaTeXConverter converter)
        {
            converters.Add(converter);
        }

        public IEnumerable<ILaTeXConverter> Get()
        {
            return converters;
        }
    }
}
