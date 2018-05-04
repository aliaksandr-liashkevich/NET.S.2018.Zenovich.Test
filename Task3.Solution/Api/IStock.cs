using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Solution.Api
{
    public interface IStock : IObservable
    {
        void Market();
    }
}
