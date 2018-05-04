using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test6.Solution.Api
{
    public interface IFunctor<TSource>
    {
        IEnumerable<TSource> Take(int count);
    }
}
