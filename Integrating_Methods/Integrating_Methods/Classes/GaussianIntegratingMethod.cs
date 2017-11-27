using Integrating_Methods.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrating_Methods.Classes
{
    public class GaussianIntegratingMethod : IIntegratingMethod
    {

        double P_n(double[] a, int n, int m, double x)
        {
            double p = 0;

            if (m == 0)
            {
                if (x == 0)
                {
                    return 0;
                }

                for (int i = 0; i <= n; i = i + 2)
                {
                    p += a[i] * Math.Pow(x, i);
                }
            }
            else
            {
                for (int i = 1; i <= n; i = i + 2)
                {
                    p += a[i] * Math.Pow(x, i);
                }
            }
            return p;
        }

       
        private double derP_n(double[] a, int n, int m, double x)
        {
            int i;
            double p = 0;
            if (m == 0)
            {
                if(x == 0)
                {
                    return 0;
                }

                for (i = 0; i <= n; i = i + 2)
                {
                    p += i * a[i] * Math.Pow(x, i - 1);
                }
            }
            else
            {
                for (i = 1; i <= n; i = i + 2)
                {
                    p += i * a[i] * Math.Pow(x, i - 1);
                }
            }
            return p;
        }


        public double Count(MethodContext context)
        {
            int n = 6;

            double[] a = new double[n+1];
            double[] y = new double[n];
            double[] z = new double[n];
            double[] w = new double[n];
            double res = 0;
            double[] u = new double[n];
            int N = 0;

            if (n % 2 == 0)
            {
                N = n / 2;
            }
            else
            {
                N = (n - 1) / 2;
            }

            // calculate coefficients of Legendre polynomial
            for (int i = 0; i <= N; i++)
            {
                a[n - 2 * i] = (Math.Pow(-1, i) * fact(2 * n - 2 * i)) / (Math.Pow(2, n) * fact(i) * fact(n - i) * fact(n - 2 * i));
            }

            // calculate coefficients
            for (int i = 0; i < n; i++)
            {
                double _a = 3.14 * (i + 0.75) / (n + 0.5);
                double _b = 3.14 * (i / n);
                z[i] = Math.Cos(3.14 * (i + 0.75) / (n + 0.5));
                y[i] = z[i];
                w[i] = 2 / ((1 - Math.Pow(z[i], 2)) * (derP_n(a, n, n % 2, z[i]) * derP_n(a, n, n % 2, z[i])));
            }

            // broaden abcisses from [-1,1] to [A,B]
            for (int i = 0; i < n; i++)
            {
                u[i] = ((context.B - context.A) * y[i] / 2) + (context.B + context.A) / 2;
            }

            for (int i = 0; i < n; i++)
            {
                res += w[i] * context.Function.Evaluate(u[i]);
            }

            res *= (context.B - context.A) / 2;

            return res;
        }


        private double fact(int n)
        {
            int i;
            double f = 1;
            for (i = 2; i <= n; i++)
            {
                f *= i;
            }
            return f;
        }
    }
}
