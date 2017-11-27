using Integrating_Methods.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrating_Methods.Classes
{
    public class SimpsonIntegratingMethod : IIntegratingMethod
    {

        public double Count(MethodContext context)
        {
            double M = context.N / 2;
            double h = (context.B - context.A) / (2 * M);

            double res = context.Function.Evaluate(context.A);

            for(int i = 1; i <= M; ++i)
            {
                res += 2 * context.Function.Evaluate(context.A + h * (2 * i - 1));
                res += 4 * context.Function.Evaluate(context.A + h * 2 * i);
            }

            res += context.Function.Evaluate(context.B);

            res *= (context.B - context.A) / (6 * M);

            return res;
        }
    }
}
