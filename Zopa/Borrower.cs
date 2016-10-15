using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zopa
{
    public class Borrower
    {
        public int RequestedAmount { get; private set; }
        public decimal Rate { get; private set; }
        public decimal MonthlyRepayment { get; private set; }
        public decimal TotalRepayment { get; private set; }
        public int Years { get; private set; }
        
        public Borrower(int amount)
        {
            if ( (amount < 1000) || (amount > 15000) || (amount % 100 != 0))
                throw new BorrowerIncorrectAmountException();
            
            RequestedAmount = amount;
            Years = 3;
        }

        public Borrower(string amount)
            : this(Convert.ToInt32(amount))
        {            
        }

        public void CalculateLoan(IList<Lender> lendersList)
        {
            var sortedList = lendersList.OrderBy(x => x.Rate);
            int currentAmount = 0;
            decimal currentRate = 0;

            foreach (var lender in sortedList)
            {
                int moneyTaken = Math.Min(RequestedAmount - currentAmount, lender.Amount);

                currentRate = ((currentAmount * currentRate) + (moneyTaken * lender.Rate)) / (currentAmount + moneyTaken);
                currentAmount += moneyTaken;

                if (currentAmount == RequestedAmount)
                {
                    Rate = currentRate;
                    break;
                }
            }

            if (currentAmount < RequestedAmount)
                throw new LendersNotAvailableException();

            TotalRepayment = CalculateRepayment();
            MonthlyRepayment = TotalRepayment / (12 * Years);        
        }

        private decimal CalculateRepayment()
        {
            return RequestedAmount * DecimalPower(1 + Rate / 12, 12 * Years);
        }

        private decimal DecimalPower(decimal x, decimal y)
        {
            Double X = (double)x;
            Double Y = (double)y;
            return (decimal)System.Math.Pow(X, Y);
        }
        
    }
}
