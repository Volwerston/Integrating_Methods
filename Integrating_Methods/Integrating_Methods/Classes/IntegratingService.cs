using Integrating_Methods.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrating_Methods.Classes
{
    public class IntegratingService
    {
        public static IIntegratingMethod GetIntegratingMethod(string name)
        {
            switch (name)
            {
                case "прямокутників":
                    return new RectangleIntegratingMethod();
                case "трапецій":
                    return new TrapezeIntegratingMethod();
                case "Сімпсона":
                    return new SimpsonIntegratingMethod();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
