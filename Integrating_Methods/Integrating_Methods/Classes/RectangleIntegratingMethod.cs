using Integrating_Methods.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrating_Methods.Classes
{
    public class RectangleIntegratingMethod : IIntegratingMethod
    {
        public double Count(MethodContext context)
        {
            double h = (context.B - context.A) / context.N;

            double toReturn = 0;

            for (int i = 0; i < context.N; ++i)
            {
                double start = context.A + i * h;
                double end = context.A + (i + 1) * h;

                toReturn += h * context.Function.Evaluate((start + end) / 2);
            }

            return toReturn;
        }
    }
}
