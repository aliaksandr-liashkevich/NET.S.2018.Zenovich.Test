using System;
using System.Collections.Generic;
using NUnit.Framework;
using Task4;
using Task4.Solution.Api;
using Task4.Solution.Services;

namespace Task4.Tests
{
    [TestFixture]
    public class TestCalculator
    {
        private readonly List<double> values = new List<double> { 10, 5, 7, 15, 13, 12, 8, 7, 4, 2, 9 };

        [Test]
        public void Test_AverageByMean()
        {
            IAverageCalculator calculator = new MeanCalculator();
            double expected = 8.3636363;

            double actual = calculator.Calculate(values);

            Assert.AreEqual(expected, actual, 0.000001);
        }

        [Test]
        public void Test_AverageByMedian()
        {
            IAverageCalculator calculator = new MedianCalculator();
            double expected = 8.0;

            double actual = calculator.Calculate(values);

            Assert.AreEqual(expected, actual, 0.000001);
        }

        [Test]
        public void Test_Client_NotFound()
        {
            Client client = new Client();
            double expected = Client.NotFound;

            double actual = client.GetAverage(values, client.GetType());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_Client_AverageByMean()
        {
            Client client = new Client();
            IAverageCalculator calculator = new MeanCalculator();
            client.Add(calculator);
            double expected = 8.3636363;

            double actual = client.GetAverage(values, typeof(MeanCalculator));

            Assert.AreEqual(expected, actual, 0.000001);
        }
    }
}