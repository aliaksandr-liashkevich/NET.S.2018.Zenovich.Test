using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.Solution.Api;

namespace Task4.Solution.Services
{
    public class Client
    {
        public static double NotFound = default(double);

        private Dictionary<Type, ICalculateAverage> _calculators;

        public Client()
        {
            _calculators = new Dictionary<Type, ICalculateAverage>();
        }

        public void Add(ICalculateAverage calculator)
        {
            _calculators.Add(calculator.GetType(), calculator);
        }

        public double GetAverage(List<double> values, Type type)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            var calculator = _calculators
               .FirstOrDefault((c) => c.GetType() == type).Value;

            if (calculator == null)
            {
                return NotFound;
            }

            return calculator.Calculate(values);
        }
    }
}
