using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zopa
{
    public class BorrowerIncorrectAmountException : Exception
    {     
        public BorrowerIncorrectAmountException()
            : base("The amount must be a valid number between 1000 and 15000 and a multiple of 100")
        {           
        }
    }

}
