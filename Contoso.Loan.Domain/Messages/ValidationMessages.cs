using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Loan.Domain.Messages
{
    public static class ValidationMessages
    {
        public static string InvalidHomeLoanInterestRate = "The interest charged on the loan must be greater than or equal to 0%";

        public static string InvalidHomeLoanTerm = "The home loan term must be between 0 and 35 years.";

        public static string InvalidHomeLoanAmount = "The principal amount of the loan must be greater than 0";
    }
}
