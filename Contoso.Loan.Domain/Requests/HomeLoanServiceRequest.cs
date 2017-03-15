using System;
using Contoso.Loan.Domain.Enums;

namespace Contoso.Loan.Domain.Requests
{
    public class HomeLoanServiceRequest
    { 
        public CurrencyType Currency { get; set; }
        public decimal Amount { get; set; }
        public int Term { get; set; }
        public decimal InterestRate { get; set; }

        public DateTime FirstRepaymentDate { get; set; }
    }
}
