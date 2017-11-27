using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrating_Methods.Classes
{
    public class Func
    {
        private readonly string prototype;

        public string Prorotype
        {
            get
            {
                return prototype;
            }
        }

        public Func(string _p)
        {
            prototype = _p;
        }

        public double Evaluate(double arg)
        {
            Argument x = new Argument("x");
            Expression exp = new Expression(prototype, x);
            x.setArgumentValue(arg);

            return exp.calculate();
        }

        public Func Derivative()
        {
            Expression exp = new Expression("der(" + Prorotype + ",x)");
            return new Func(exp.getExpressionString());
        }

        public Func Derivative(int n)
        {
            if (n == 1)
            {
                return this.Derivative();
            }

            return this.Derivative().Derivative(n - 1);
        }
    }
}
