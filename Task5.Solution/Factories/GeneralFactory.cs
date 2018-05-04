using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Solution.Api;

namespace Task5.Solution.Factories
{
    public class GeneralFactory : IFactory<IConverter>
    {
        private List<IConverter> converters = new List<IConverter>();

        public void Add(IConverter converter)
        {
            converters.Add(converter);
        }

        public IEnumerable<IConverter> Get()
        {
            return converters;
        }
    }
}
