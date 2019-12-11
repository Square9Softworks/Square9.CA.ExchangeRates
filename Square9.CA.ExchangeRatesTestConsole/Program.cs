using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Square9.CA.ExchangeRatesTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ExchangeRates.AssemblyLogic logic = new ExchangeRates.AssemblyLogic();
            Dictionary<string, string> testData = new Dictionary<string, string>();
            testData.Add("-2", "");
            testData.Add("1", "Amount:65329.28");
            testData.Add("3", "Currency:GBP");
            testData.Add("4", "Converted:");       
            testData.Add("5", "");
            testData.Add("7", null);

            Console.WriteLine("Call Assembly Test - Rate Conversion");

            Dictionary<string,string> processed = logic.RunCallAssembly(testData);
            
            foreach(String item in processed.Keys)
            {
                Console.WriteLine(item + " - " + processed[item]);
            }

            Console.Read();
        }
    }
}
