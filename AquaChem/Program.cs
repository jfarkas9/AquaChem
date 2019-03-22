using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaChem
{
    class Program
    {
        /*TODO Overall
         * 
         * Catch wrong entries in newtestresult. number entries only
         * 
         * 
         * save to binary?
         * connect to database
         * save to database
         * save to text file?
         * 
         * 
         */ 


        static void Main(string[] args)
        {
            String choice;
            List<Stat> Stats = new List<Stat>();

            //////////// TODO To be removed / for testing only
            List<Stat> TestStats = new List<Stat>();
            TestStats.Add(new Stat(DateTime.Now, 1, 1, 1, 1, 1));
            TestStats.Add(new Stat(DateTime.Now, 1, 1, 1, 1, 1));
            TestStats.Add(new Stat(DateTime.Now, 7, 7, 7, 7, 7));
            TestStats.Add(new Stat(DateTime.Now, 3, 3, 3, 3, 3));
            TestStats.Add(new Stat(DateTime.Now, 2, 2, 2, 2, 2));
            Stats = TestStats;
            ///////////
            do
            {
                Console.WriteLine("Aquarium Chemistry Tracker");
                Console.WriteLine("1. Enter New Results");
                Console.WriteLine("2. View Results");
                Console.WriteLine("3. Clear Stored Results");
                Console.WriteLine("4. Quit");
                Console.Write("Enter Choice: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        //Ask user for new test results and add to list
                        Console.Clear();
                        NewTestResult(Stats);
                        Console.Clear();
                        break;
                    case "2":
                        //opens the display menu
                        Console.Clear();
                        DisplayResults(Stats);
                        Console.Clear();
                        break;
                    case "3":
                        Console.Clear();
                        //clearData(Stats);
                        //local or database?
                        Stats.Clear();
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter a number 1-4");
                        break;
                }
                
            } while (choice != "4");

        }//end main

        private static void DisplayResults(List<Stat> stats)
        {
            if ((stats is null) || (stats.Count == 0))
            {
                Console.WriteLine("Cannot  display stats, null or empty");
                Console.ReadLine();
                return;
            }

            String choice;
            Console.WriteLine("1. View List");
            Console.WriteLine("2. View Change");
            Console.WriteLine("3. View Graph");
            Console.WriteLine("4. Previous Menu");
            Console.Write("Enter Choice: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine(DisplayList(stats));
                    Console.ReadLine();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine(DisplayChange(stats));
                    Console.ReadLine();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine(DisplayGraph(stats));
                    Console.ReadLine();
                    break;
                case "4":
                    //return to previous menu
                    return;
                default:
                    //catches 
                    Console.WriteLine("Please enter a number 1-4");
                    break;
            }

        }

        private static string DisplayGraph(List<Stat> stats)
        {
            //Any way to refactor to pass to a method?
            String choice;
            String output = "";
            Console.WriteLine("Select the value to be graphed:");
            Console.WriteLine("1. Temperature");
            Console.WriteLine("2. PH");
            Console.WriteLine("3. Ammonia");
            Console.WriteLine("4.Nitrites");
            Console.WriteLine("5. Nitrates");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    foreach (Stat item in stats)
                    {
                        output += item.Date.ToShortDateString();
                        for (int i = 0; i < item.Temperature; i++)
                        {
                            output +="*";
                        }
                        output += "\n";
                    }
                    break;
                case "2":
                    Console.Clear();
                    Console.Clear();
                    foreach (Stat item in stats)
                    {
                        output += item.Date.ToShortDateString();
                        for (int i = 0; i < item.PH; i++)
                        {
                            output += "*";
                        }
                        output += "\n";
                    }
                    break;
                case "3":
                    Console.Clear();
                    foreach (Stat item in stats)
                    {
                        output += item.Date.ToShortDateString();
                        for (int i = 0; i < item.Ammonia; i++)
                        {
                            output += "*";
                        }
                        output += "\n";
                    }
                    break;
                case "4":
                    Console.Clear();
                    Console.Clear();
                    foreach (Stat item in stats)
                    {
                        output += item.Date.ToShortDateString();
                        for (int i = 0; i < item.Nitrites; i++)
                        {
                            output += "*";
                        }
                        output += "\n";
                    }
                    break;
                case "5":
                    Console.Clear();
                    foreach (Stat item in stats)
                    {
                        output += item.Date.ToShortDateString();
                        for (int i = 0; i < item.Nitrates; i++)
                        {
                            output += "*";
                        }
                        output += "\n";
                    }
                    break;
                default:
                    //catches 
                    Console.WriteLine("Please enter a number 1-5");
                    break;
            }

            return output;
        }

        public static String DisplayChange(List<Stat> stats)
        {
            String output = "Value Highest Lowest Average\n";

            //easier way of iterating through object properties?
            
            decimal maxTemp = stats.Max(t => t.Temperature);
            decimal minTemp = stats.Min(t => t.Temperature);
            decimal avgTemp = stats.Average(t => t.Temperature);
            output += $"Temperature: {maxTemp} {minTemp} {avgTemp}\n";

            decimal maxPh = stats.Max(t => t.PH);
            decimal minPh = stats.Min(t => t.PH);
            decimal avgPh = stats.Average(t => t.PH);
            output += $"Ph: {maxPh} {minPh} {avgPh}\n";

            decimal maxAmm = stats.Max(t => t.Ammonia);
            decimal minAmm = stats.Min(t => t.Ammonia);
            decimal avgAmm = stats.Average(t => t.Ammonia);
            output += $"Ammonia: {maxAmm} {minAmm} {avgAmm}\n";

            decimal maxNi = stats.Max(t => t.Nitrites);
            decimal minNi = stats.Min(t => t.Nitrites);
            decimal avgNi = stats.Average(t => t.Nitrites);
            output += $"Nitrites: {maxNi} {minNi} {avgNi}\n";

            decimal maxNa = stats.Max(t => t.Nitrates);
            decimal minNa = stats.Min(t => t.Nitrates);
            decimal avgNa = stats.Average(t => t.Nitrates);
            output += $"Nitrates: {maxNa} {minNa} {avgNa}\n";

           

            return output;
        }

        
        private static String DisplayList(List<Stat> stats)
        {
            //TODO cleanup and lineup print
            String output = "Date      Temp   pH     Ammonia   Nitrites Nitrates\n";
            foreach(Stat item in stats)
            {
                output += $"{item.Date} {item.Temperature} {item.PH} {item.Ammonia} {item.Nitrites} {item.Nitrates}\n";
            }
                        
            return output;
        }

        private static void NewTestResult(List<Stat> stats)
        {
            DateTime date;
            
            Console.Write("Use today's date? Y/N: ");
            string choice = Console.ReadLine();

            if(choice.ToUpper() == "Y")
            {
                //use current date
                date = DateTime.Now;
            }else if(choice.ToUpper() == "N")
            {
                // TODO add input date
                date = DateTime.Now; //remove once implemented
            }
            else
            {
                //for all other entries, use current date
                date = DateTime.Now;
            }

            Console.WriteLine("Enter new stats:");

            Console.Write("Temperature: ");
            decimal temperature = Decimal.Parse(Console.ReadLine());

            Console.Write("pH: ");
            decimal pH = Decimal.Parse(Console.ReadLine());

            Console.Write("Ammonia: ");
            decimal ammonia = Decimal.Parse(Console.ReadLine());

            Console.Write("Nitrites: ");
            decimal nitrites = Decimal.Parse(Console.ReadLine());

            Console.Write("Nitrates: ");
            decimal nitrates = Decimal.Parse(Console.ReadLine());
           
            Stat newstat = new Stat(date, temperature, pH, ammonia, nitrates, nitrates);

            Console.WriteLine("New Stat Added");
            Console.ReadLine();
           
            //TODO add to database
            stats.Add(newstat);
            
            //insertStat(stat);

            //if successful return true
        }


        
    }//end program
}//end aquachem
