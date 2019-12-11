using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace Square9.CA.ExchangeRates
{
    public class AssemblyLogic
    {
        public Dictionary<string, string> RunCallAssembly(Dictionary<string, string> Input)
        {
            Dictionary<string, string> Output = new Dictionary<string, string>();
            String url = "https://api.ratesapi.io/api/latest?base=USD";

            String amount = "";
            String currency = "";
            String returnKey = "";

            foreach(String item in Input.Keys)
            {
                if (!String.IsNullOrEmpty(Input[item]) && Input[item].ToUpper().StartsWith("AMOUNT:"))
                    amount = Input[item].Substring(7);

                if (!String.IsNullOrEmpty(Input[item]) && Input[item].ToUpper().StartsWith("CURRENCY:"))
                    currency = Input[item].Substring(9);

                if (!String.IsNullOrEmpty(Input[item]) && Input[item].ToUpper().StartsWith("CONVERTED:"))
                    returnKey = item;
            }

            if (amount == "" || currency == "" || returnKey == "")
            {
                Console.WriteLine(DateTime.Now.ToString() + "\tMissing required parameters.");
                return Output;
            }

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    String jsonStr = reader.ReadToEnd();
                    dynamic exchange = JsonConvert.DeserializeObject(jsonStr);
                    double currentRate = exchange.rates[currency].Value;
                    Console.WriteLine(DateTime.Now.ToString() + "\tCurrent rate for " + currency + " is " + currentRate.ToString());
                    double converted = currentRate * Convert.ToDouble(amount);
                    Console.WriteLine(DateTime.Now.ToString() + "\tConverted amount is " + Math.Round(converted, 2).ToString());

                    Output.Add(returnKey, Math.Round(converted, 2).ToString());
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(DateTime.Now.ToString() + "\t" + ex.Message);
            }

            return Output;
        }
    }
}
