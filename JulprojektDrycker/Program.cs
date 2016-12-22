using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JulprojektDrycker
{
    class DbMiddleware
    {
        public static List<Beer> beerList = new List<Beer>();
        public static List<Wine> wineList = new List<Wine>();
        public static List<Whisky> WhiskyList = new List<Whisky>();

        public static string category;
        private Dictionary<int, string> categoryDict = new Dictionary<int, string>()
        {
            { 1, "beer"}, {2,"wine" }, { 3, "whisky"}
        };

        // Prints those lists that aren't empty
        private static void PrintLists()
        {
            if (beerList.Count > 0)
            {
                Console.WriteLine("--- Beer Inputs ---");
                foreach (Beer b in beerList)
                {
                    Console.WriteLine("{0}, {1}, {2}\n{3}", b.Name, b.Type, b.AlcProcent, b.Description);
                }
            }
            if (wineList.Count > 0)
            {
                Console.WriteLine("--- Wine Inputs ---");
                foreach (Wine b in wineList)
                {
                    Console.WriteLine("{0}, {1}, {2}\n{3}", b.Name, b.Type, b.AlcProcent, b.Description);
                }
            }
            if (WhiskyList.Count > 0)
            {
                Console.WriteLine("--- Whisky Inputs ---");
                foreach (Whisky b in WhiskyList)
                {
                    Console.WriteLine("{0}, {1}, {2}\n{3}", b.Name, b.Type, b.AlcProcent, b.Description);
                }
            }
        }

        // Checks if input string is convertable to int and if it's a key in the dictionary.
        // If true; sets category accordingly.
        public bool checkCategory(string s)
        {
            int key;

            if (int.TryParse(s, out key))
            {
                if (categoryDict.ContainsKey(key))
                {
                    category = categoryDict[key];
                    Form.PrintForm(category);
                    return true;
                }
                else if (key == 9)
                {
                    PrintLists();
                    return true;
                }
                else if (key == 0)
                {
                    return true;
                }
            }
            return false;
        }


    }
    class Form
    {
        // If User is bad and writes string instead of double or int. Sets value to 0.0...
        public static double validateProcent(string s)
        {
            double d;
            if (s.Contains(","))
            {
                s.Replace(",", ".");
            }
            if(double.TryParse(s, out d))
            {
                return d;
            }
            else
            {
                return 0.0;
            }

        }
        public static void PrintForm(string category)
        {
            Console.WriteLine("Generating form for '{0}'.", category);
            Console.Write("\nName: ");
            string name = Console.ReadLine();
            Console.Write("\nType: ");
            string type = Console.ReadLine();
            Console.Write("\n%: ");
            string p = Console.ReadLine();
            Console.Write("\nDescription: ");
            string desc = Console.ReadLine();
            Console.WriteLine();

            double d = validateProcent(p);

            switch (category)
            {
                case "beer":
                    DbMiddleware.beerList.Add(new Beer(name,type,d,desc));
                    break;
                case "wine":
                    DbMiddleware.wineList.Add(new Wine(name, type, d, desc));
                    break;
                case "whisky":
                    DbMiddleware.WhiskyList.Add(new Whisky(name, type, d, desc));
                    break;
                default:
                    break; // Shouldn't get here.                
            }
            
        }
        
    }


    // TODO Kommentera bättre
    

    class Program
    {        
        public static void PrintMenu()
        {
            Console.WriteLine("Welcome to my minified database of beverages!\nSelect category item with a number.\n");
            Console.WriteLine("1 - Beer\n2 - Wine\n3 - Whisky\n9 - List all your added things\n0 - Exit");
        }
        static void Main(string[] args)
        {
            DbMiddleware middleware = new DbMiddleware();

            string s = "";
            while (!s.Equals("0"))
            {
                PrintMenu();
                s = Console.ReadLine();

                while (!middleware.checkCategory(s))
                {
                    Console.WriteLine("Bad input, try again.");
                    s = Console.ReadLine();
                }

//                Console.WriteLine("Chosen category: {0}", middleware.category);


            }           
           
        }
    }
}
