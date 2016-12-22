using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JulprojektDrycker
{
    class Wine : IBeverage
    {
        string name = default(string);
        string wineType = default(string);
        double procent = default(double);
        string desc = default(string);

        public double AlcProcent
        {
            get
            {
                return procent;
            }

            set
            {
                procent = value;
            }
        }

        public string Description
        {
            get
            {
                return desc;
            }

            set
            {
                desc = value;
            }
        }

        public string Type
        {
            get
            {
                return wineType;
            }

            set
            {
                wineType = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public Wine(string n, string t, double proc, string d)
        {
            name = n; wineType = t; procent = proc; desc = d;
        }

    }
    class Beer : IBeverage
    {
        string name = default(string);
        string beerType = default(string);
        double procent = default(double);
        string desc = default(string);


        public double AlcProcent
        {
            get
            {
                return procent;
            }

            set
            {
                procent = value;
            }
        }

        public string Description
        {
            get
            {
                return desc;
            }

            set
            {
                desc = value;
            }
        }

        public string Type
        {
            get
            {
                return beerType;
            }

            set
            {
                beerType = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        public Beer(string n, string t, double proc, string d)
        {
            name = n; beerType = t; procent = proc; desc = d;
        }
    }
    class Whisky : IBeverage
    {
        string name = default(string);
        string whiskyType = default(string);
        double procent = default(double);
        string desc = default(string);

        public double AlcProcent
        {
            get
            {
                return procent;
            }

            set
            {
                procent = value;
            }
        }

        public string Description
        {
            get
            {
                return desc;
            }

            set
            {
                desc = value;
            }
        }

        public string Type
        {
            get
            {
                return whiskyType;
            }

            set
            {
                whiskyType = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        public Whisky(string n, string t, double proc, string d)
        {
            name = n; whiskyType = t; procent = proc; desc = d;
        }
    }
}