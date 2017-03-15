using System;
using System.Collections.Generic;
using Contoso.Loan.Domain.Enums;
using Contoso.Loan.Domain.Interfaces;
using Contoso.Loan.Domain.Loans;
using Contoso.Loan.Domain.Rules;

namespace Contoso.Loan.Domain.Responses
{
    public class HomeLoanResponse
    {
        public HomeLoanResponse()
        {
            BrokenBusinessRules = new List<BusinessRule>();
            PaymentPlan = new List<IPayment>();
        }

        public ServiceStatus Status { get; set; }
        public decimal MonthlyPayment { get; set; }
        public decimal Principle { get; set; }
        public decimal InterestTotal { get; set; }
        public decimal TotalRepaymentAmount { get; set; }
        public HomeLoan Loan { get; set; }
        public List<IPayment> PaymentPlan { get; set; }
        public List<BusinessRule> BrokenBusinessRules { get; set; }
    }
}
