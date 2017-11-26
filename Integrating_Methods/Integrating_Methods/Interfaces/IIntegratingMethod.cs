using Integrating_Methods.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrating_Methods.Interfaces
{
    public interface IIntegratingMethod
    {
        double Count(MethodContext context);
    }
}
