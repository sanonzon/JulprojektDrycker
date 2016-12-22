using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JulprojektDrycker
{
    interface IBeverage
    {
        string Name { get; set; }
        string Type { get; set; }
        double AlcProcent { get; set; }
        string Description { get; set; }
    }
}
