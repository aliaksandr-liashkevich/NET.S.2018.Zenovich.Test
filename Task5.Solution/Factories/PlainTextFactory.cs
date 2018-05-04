using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Solution.Api;
using Task5.Solution.Api.Converters;

namespace Task5.Solution.Factories
{
    public class PlainTextFactory : IFactory<IPlainTextConverter>
    {
        private List<IPlainTextConverter> converters = new List<IPlainTextConverter>();

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
