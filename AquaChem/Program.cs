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
         * finish viewlist
         * rename to printlist?
         * Catch wrong entries in newtestresult. number entries only
         * 
         * Update
         * Delete
         *  single
         *  all
         *  binary/database
         * View
         * Search 
         * 
         * save to binary
         * connect to database
         * save to database
         * save to text file?
         * 
         * DONE
         * Insert
         */ 


        static void Main(string[] args)
        {
            String choice;
            List<Stat> Stats = new List<Stat>();
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
                        //clearData
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
                    Console.WriteLine(ViewList(stats));
                    Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine(ViewChange(stats));
                    Console.ReadLine();
                    break;
                case "3":
                    //ViewGraph(stats);
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

        private static String ViewChange(List<Stat> stats)
        {
            String output = "Value         Highest Lowest Average\n";
            decimal maxTemp = stats.Max(t => t.Temperature);

            output += $"Temperature: {maxTemp}";

            return output;
        }

        private static String ViewList(List<Stat> stats)
        {
            String output = "Date      Temp   pH     Ammonia   Nitrites Nitrates\n";
            foreach(Stat item in stats)
            {
                //TODO cleanup and lineup print
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
        }


        
    }//end program
}//end aquachem
