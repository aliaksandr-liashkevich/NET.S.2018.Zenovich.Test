using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Solution.Api;
using Task3.Solution.Observables;
using Task3.Solution.Observers;

using SysConsole = System.Console;

namespace Task3.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IStock stock = new Stock();

            IObserver bank = new Bank("Alpha", stock);
            IObserver broker = new Broker("BrokerBlack", stock);

            stock.Market();

            SysConsole.ReadKey();
        }
    }
}
