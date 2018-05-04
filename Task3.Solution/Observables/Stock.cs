using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Solution.Api;
using Task3.Solution.Models;

namespace Task3.Solution.Observables
{
    public class Stock : IObservable
    {
        public event Action<object> ObservableEvent = delegate { };

        private StockInfo stocksInfo;

        public Stock()
        {
            stocksInfo = new StockInfo();
        }

        public void Register(IObserver observer) => ObservableEvent += observer.Update;

        public void Unregister(IObserver observer) => ObservableEvent -= observer.Update;

        public void Notify()
        {
            ObservableEvent.Invoke(stocksInfo);
        }

        public void Market()
        {
            Random rnd = new Random();
            stocksInfo.USD = rnd.Next(20, 40);
            stocksInfo.Euro = rnd.Next(30, 50);
            Notify();
        }
    }
}
