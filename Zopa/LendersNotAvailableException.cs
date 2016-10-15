using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zopa
{
    public class LendersNotAvailableException : Exception
    {
        public LendersNotAvailableException()
            : base("The market does not have sufficient offers from lenders to satisfy the loan")
        { }

    }
}
