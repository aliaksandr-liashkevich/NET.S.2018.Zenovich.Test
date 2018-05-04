using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Test6.Solution;
using Test6.Solution.Api;

namespace Task6.Tests
{
    [TestFixture]
    public class CustomEnumerableTests
    {
        [Test]
        public void Generator_ForSequence1()
        {
            IFunctor<int> generator = new InfinityCollection<int>(1, 1, (x, y) => x+y);
            int[] expected = {1, 1, 2, 3, 5, 8, 13, 21, 34, 55};

            int[] actual = generator.Take(expected.Length).ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Generator_ForSequence2()
        {
            IFunctor<int> generator = new InfinityCollection<int>(1, 2, (x, y) => 6*y - 8*x);
            int[] expected = { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512 };

            int[] actual = generator.Take(expected.Length).ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Generator_ForSequence3()
        {
            IFunctor<double> generator = new InfinityCollection<double>(1, 2, (x, y) => y + x / y);
            double[] expected = { 1, 2, 2.5, 3.3, 4.05757575757576, 4.87086926018965, 5.70389834408211, 6.55785277425587, 7.42763417076325, 8.31053343902137 };

            double[] actual = generator.Take(expected.Length).ToArray();

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i], 0.0000001);
            }
        }
    }
}
