using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Loan.Mvc.Configuration
{
    public interface ILoanDefaultConfiguration
    {
        decimal DefaultInterestRate { get; }
        int DefaultLoanAmount { get; } 
        int DefaultLoanTerm { get; }
    }
}
