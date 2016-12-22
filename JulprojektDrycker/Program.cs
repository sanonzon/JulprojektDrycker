using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JulprojektDrycker
{
    class Form
    {
        public static void PrintForm(string category)
        {
            Console.WriteLine("Generating form for '{0}'", category);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }
        
    }


    // TODO Kommentera bättre
    class DbMiddleware
    {
        public static List<Beer> beerList = new List<Beer>();
        public static List<Wine> wineList = new List<Wine>();
        public static List<Whisky> WhiskyList = new List<Whisky>();

        public string category;
        private Dictionary<int, string> categoryDict = new Dictionary<int, string>()
        {
            { 1, "beer"}, {2,"wine" }, { 3, "whisky"}
        };

        // Prints those lists that aren't empty
        private static void PrintLists()
        {
            if (beerList.Count > 0)
            {
                foreach(Beer b in beerList)
                {
                    Console.WriteLine("{0}, {1}, {2}\n{3}",b.Name,b.Type,b.AlcProcent,b.Description);
                }
            }
            if (wineList.Count > 0)
            {
                foreach (Wine b in wineList)
                {
                    Console.WriteLine("{0}, {1}, {2}\n{3}", b.Name, b.Type, b.AlcProcent, b.Description);
                }
            }
            if (WhiskyList.Count > 0)
            {
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
                    return true;                    
                }
                else if (key == 9)
                {
                    PrintLists();
                }
            }
            return false;
        }


    }

    class Program
    {        
        static void Main(string[] args)
        {
            DbMiddleware middleware = new DbMiddleware();

            Console.WriteLine("Welcome to my minified database of beverages!\nSelect category item with a number.\n");
            Console.WriteLine("1 - Beer\n2 - Wine\n3 - Whisky\n9 - List all your added things\n0 - Exit");
            string s = Console.ReadLine();

            while (!middleware.checkCategory(s))
            {
                Console.WriteLine("Bad input, try again.");
                s = Console.ReadLine();
            }

            Console.WriteLine("Chosen category: {0}",middleware.category);

            
        }
    }
}
