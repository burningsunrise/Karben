using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karben
{
    class WeightChanceExecutor
    {
        public WeightedChanceParam[] Parameters { get; }
        private Random r;

        public double RatioSum
        { 
            get { return Parameters.Sum(p => p.Ratio); }
        }

        public WeightChanceExecutor(params WeightedChanceParam[] parameters)
        {
            Parameters = parameters;
            r = new Random();
        }

        public void Execute()
        {
            double numericValue = r.NextDouble() * RatioSum;
            
            foreach (var parameter in Parameters)
            {
                numericValue -= parameter.Ratio;

                if (!(numericValue <= 0))
                    continue;

                parameter.Func();
                return;
            }
        }
    }
}
