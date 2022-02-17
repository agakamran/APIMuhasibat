using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIMuhasibat.Models
{
    interface IAbstractFactory
    {
        IAbstractQrup CreateQrup();
    }
}
