using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.Solution.Api;

namespace Task4.Solution.Services
{
    public class UserCalculator : IAverageCalculator
    {
        public double Calculate(List<double> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            return values.Average();
        }
    }
}
