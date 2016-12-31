using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JulprojektDrycker
{
    // My shitty wannabe database.
    class DbMiddleware
    {
        public static List<Beer> beerList = new List<Beer>();
        public static List<Wine> wineList = new List<Wine>();
        public static List<Whisky> whiskyList = new List<Whisky>();

        public static string category;
        private Dictionary<int, string> categoryDict = new Dictionary<int, string>()
        {
            { 1, "beer"}, {2,"wine" }, { 3, "whisky"}
        };

        // Prints the every List that isn't empty
        private static void PrintLists()
        {
            if (beerList.Count > 0)
            {
                Console.WriteLine("\n--- Beer Inputs ---");
                foreach (Beer b in beerList)
                {
                    string procentFix = b.AlcProcent + "%";
                    Console.WriteLine("{0}, {1}, {2}.\n{3}", b.Name, b.Type, procentFix, b.Description);
                }
            }
            if (wineList.Count > 0)
            {
                Console.WriteLine("\n--- Wine Inputs ---");
                foreach (Wine b in wineList)
                {
                    string procentFix = b.AlcProcent + "%";                    
                    Console.WriteLine("{0}, {1}, {2}.\n{3}", b.Name, b.Type, procentFix, b.Description);
                }
            }
            if (whiskyList.Count > 0)
            {
                Console.WriteLine("\n--- Whisky Inputs ---");
                foreach (Whisky b in whiskyList)
                {
                    string procentFix = b.AlcProcent + "%";
                    Console.WriteLine("{0}, {1}, {2}.\n{3}", b.Name, b.Type, procentFix, b.Description);
                }
            }
        }


        // Search for a Beverage in each List.
        public void Search()
        {
            Console.Write("Search for (name): ");
            string s = Console.ReadLine();

            List<IBeverage> result = new List<IBeverage>();
            foreach(Whisky b in whiskyList)
            {
                if (b.Name.Contains(s))
                {
                    result.Add(b);
                }
            }
            foreach(Wine b in wineList)
            {
                if (b.Name.Contains(s))
                {
                    result.Add(b);
                }
            }
            foreach(Beer b in beerList)
            {
                if (b.Name.Contains(s))
                {
                    result.Add(b);
                }
            }

            if (result.Count > 0)
            {
                PrintSearchResult(result);
            }

        }


        // Prints the Results. Can get which class type it is with:
        //      item.ToString().Substring(item.ToString().LastIndexOf(".")+1)
        //      Getting either Beer, Wine, Whisky or Stout.
        //      But i choose not to do that.
        public void PrintSearchResult(List<IBeverage> result)
        {
            Console.WriteLine("\n--- RESULTS ---");
            foreach(var item in result)
            {
                string procentFix = item.AlcProcent + "%";
                Console.WriteLine("{0}, {1}, {2}.\n{3}", item.Name, item.Type, procentFix, item.Description);
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
            }
            else if (s.ToLower().Equals("search")){
                Search();
                return true;                
            }
            else if (s.ToLower().Equals("exit"))
            {
                return true;
            }
            return false;
        }


    }
    class Form
    {
        // If User is bad and writes string instead of double or int. Sets value to 0.0...
        public static string ReplaceComma(string s)
        {            
            if (s.Contains(".")) 
            {
               s = s.Replace(".", ",");
            }
            return s;
        }
        public static bool ValidateDouble(string s)
        {            
            try
            {
                double.Parse(s);
            }
            catch (FormatException)
            {
                Console.WriteLine("'{0}' is not a number, stop being a retard.",s);
                return false;
            }
            catch(OverflowException)
            {
                Console.WriteLine("Value was either too large or too small for a Double.");
                return false;
            }

            return true;            
        }

        // Prints a Form wiht input info to add a New Beverage. 
        // It's Generic. Generating form for <category> is just for Human reminder.
        public static void PrintForm(string category)
        {

            Console.WriteLine("Generating form for '{0}'.", category);
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Type: ");
            string type = Console.ReadLine();

            Console.Write("Percentage Alcohol: ");
            string p = ReplaceComma(Console.ReadLine());            

            while (!ValidateDouble(p))
            {
                Console.Write("Percentage Alcohol: ");
                p = ReplaceComma(Console.ReadLine());
            }
            double d = double.Parse(p);



            Console.Write("Description: ");
            string desc = Console.ReadLine();
            Console.WriteLine();



            // Puts new info into correct List. A Joined List would work, yes, but i didn't want to build it like that.
            switch (category)
            {
                case "beer":
                    if (type.ToLower().Equals("stout"))
                    {
                        DbMiddleware.beerList.Add(new Stout(name, type, d, desc));
                    }else
                    {
                        DbMiddleware.beerList.Add(new Beer(name, type, d, desc));
                    }                    
                    break;
                case "wine":
                    DbMiddleware.wineList.Add(new Wine(name, type, d, desc));
                    break;
                case "whisky":
                    DbMiddleware.whiskyList.Add(new Whisky(name, type, d, desc));
                    break;
                default:
                    break; // Shouldn't get here.                
            }
            
        }
        
    }

    
    class Program
    {        
        // The menu of things to choose from.
        public static void PrintMenu()
        {
            Console.WriteLine("1 - Add Beer\n2 - Add Wine\n3 - Add Whisky\n9 - List all your added things\nSearch - NEW FEATURE! Search for a beverage!\nExit - Terminate program.");
            Console.Write("Choice: ");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("\n\nWelcome to my minified database of beverages!\nSelect category item with a number.");
            DbMiddleware middleware = new DbMiddleware();

            string s = "";

            // Loop until User chooses to exit.
            while (!s.ToLower().Equals("exit"))
            {
                PrintMenu();
                s = Console.ReadLine();

                while (!middleware.checkCategory(s))
                {
                    Console.WriteLine("Bad input, try again.\nChoice: ");
                    s = Console.ReadLine();
                }
            }                      
        }
    }
}
