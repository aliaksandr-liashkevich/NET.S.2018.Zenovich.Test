using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution.Api
{
    public interface IFactory<out T>
        where T : IConverter
    {
        IEnumerable<T> Get();
    }
}
