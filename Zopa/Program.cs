using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zopa
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() != 2)
            {
                Console.WriteLine("The number of arguments is not correct. [Arg1 = market file] [Arg2 = loan amount]");
                Environment.Exit(0);
            }

            try
            {
                IList<Lender> lenders = Lender.GetLendersList(args[0]);

                Borrower br = new Borrower(args[1]);
                br.CalculateLoan(lenders);

                Console.WriteLine(string.Format("Requested amount: £{0}", br.RequestedAmount));
                Console.WriteLine(string.Format("Rate: {0:0.0}%", br.Rate*100));
                Console.WriteLine(string.Format("Monthly repayment: £{0:0.00}", br.MonthlyRepayment));
                Console.WriteLine(string.Format("Total repayment: £{0:0.00}", br.TotalRepayment));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }
    }
}
