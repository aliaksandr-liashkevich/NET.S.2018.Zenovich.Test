using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test6.Solution.Api;

namespace Test6.Solution
{
    public class InfinityCollection<TSource> : IFunctor<TSource>
    {
        private TSource firstElement;
        private TSource secondElement;

        private Func<TSource, TSource, TSource> funcNextElement;

        public InfinityCollection(TSource firstElement, TSource secondElement,
            Func<TSource, TSource, TSource> funcNextElement)
        {
            this.firstElement = firstElement;
            this.secondElement = secondElement;
            this.funcNextElement = funcNextElement;
        }


        public IEnumerable<TSource> Take(int count)
        {
            IEnumerable<TSource> sources = Generate(firstElement, secondElement , funcNextElement)
                .Take(count);

            return sources;
        }

        private IEnumerable<TSource> Generate<TSource>(TSource first, TSource second,
            Func<TSource, TSource, TSource> func)
        {
            yield return first;
            yield return second;

            TSource temp = default(TSource);

            while (true)
            {
                temp = second;
                second = func(first, second);
                first = temp;

                yield return second;
            }     
        }

    }
}
