using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Solution.Api;
using Task5.Solution.Api.Converters;

namespace Task5.Solution.Factories
{
    public class HtmlFactory : IFactory<IHtmlConverter>
    {
        private List<IHtmlConverter> converters;

        public void Add(IHtmlConverter converter)
        {
            converters.Add(converter);
        }

        public IEnumerable<IHtmlConverter> Get()
        {
            return converters;
        }
    }
}
