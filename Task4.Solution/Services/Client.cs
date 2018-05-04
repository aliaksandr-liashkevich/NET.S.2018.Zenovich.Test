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

        private Dictionary<Type, IAverageCalculator> _calculators;

        public Client()
        {
            _calculators = new Dictionary<Type, IAverageCalculator>();
        }

        public void Add(IAverageCalculator calculator)
        {
            if (calculator == null)
            {
                throw new ArgumentNullException(nameof(calculator));
            }

            _calculators.Add(calculator.GetType(), calculator);
        }

        public double GetAverage(List<double> values, Type type)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            var calculator = _calculators
               .FirstOrDefault((c) => c.Key == type).Value;

            if (calculator == null)
            {
                return NotFound;
            }

            return calculator.Calculate(values);
        }
    }
}
