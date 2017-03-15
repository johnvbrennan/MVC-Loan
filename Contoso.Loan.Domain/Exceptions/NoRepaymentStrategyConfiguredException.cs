using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Loan.Domain.Exceptions
{
    public class NoRepaymentStrategyConfiguredException : Exception
    {
        public NoRepaymentStrategyConfiguredException() : base()
        { 
        }

        public NoRepaymentStrategyConfiguredException(string message) : base(message)
        { 
        } 
    }
}
