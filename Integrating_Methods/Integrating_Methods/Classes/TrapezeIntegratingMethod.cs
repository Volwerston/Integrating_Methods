using Integrating_Methods.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrating_Methods.Classes
{
    public class TrapezeIntegratingMethod : IIntegratingMethod
    {
        public double Count(MethodContext context)
        {
            double h = (context.B - context.A) / context.N;

            double toReturn = context.Function.Evaluate(context.A);

            for (int i = 1; i < context.N; ++i)
            {
                toReturn += 2* context.Function.Evaluate(context.A + i * h);
            }

            toReturn += context.Function.Evaluate(context.B);

            toReturn *= (context.B - context.A) / (2 * context.N);

            return toReturn;
        }
    }
}
