using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Solution.Api;
using Task5.Solution.Api.Converters;

namespace Task5.Solution.Factories
{
    class PlainTextFactory : IFactory<IPlainTextConverter>
    {
        private List<IPlainTextConverter> converters;

        public void Add(IPlainTextConverter converter)
        {
            converters.Add(converter);
        }

        public IEnumerable<IPlainTextConverter> Get()
        {
            return converters;
        }
    }
}
