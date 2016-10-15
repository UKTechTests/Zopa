using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zopa
{
    public class Lender
    {
        public string Name { get; private set; }
        public decimal Rate { get; private set; }
        public int Amount { get; private set; }

        public Lender(string name, decimal rate, int amount)
        {
            Name = name;
            Rate = rate;
            Amount = amount;
        }

        public static IList<Lender> GetLendersList(string fileName)
        {
            IList<Lender> lendersList = new List<Lender>();

            using (StreamReader sr = new StreamReader(fileName))
            {
                string header = sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    string record = sr.ReadLine();

                    try
                    {
                        string[] values = record.Split(',');
                        string name = values[0];
                        decimal rate = Convert.ToDecimal(values[1]);
                        int amount = Convert.ToInt32(values[2]);
                        lendersList.Add(new Lender(name, rate, amount));
                    }
                    catch (Exception)
                    {                        
                        throw;
                    }

                }            
            }

            return lendersList;
        }
    }
}
