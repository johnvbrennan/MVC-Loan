using System;
using System.Collections.Generic;
using Contoso.Loan.Domain.Enums;
using Contoso.Loan.Domain.Interfaces;
using Contoso.Loan.Domain.Messages;
using Contoso.Loan.Domain.RepaymentStrategies;
using Contoso.Loan.Domain.Rules;

namespace Contoso.Loan.Domain.Loans
{
    public class HomeLoan : BankLoanBase
    {           
        public HomeLoan(decimal principal, int term, decimal interestRatePercentage, CurrencyType currency) : base(principal, term, interestRatePercentage, currency)
        {
        }
         
        protected override IRepaymentStrategy CreateRepaymentStrategy()
        {
           return new MonthlyRepaymentStrategy();
        }

        public decimal PropertyValue { get; set; }

        public decimal Deposit { get; set; }

        protected override void CheckForBrokenBusinessRulesOnThisLoan()
        {
            if (Principal <= 0)
            {
                _businessRules.Add(new BusinessRule() { Name = "Principal", Description = ValidationMessages.InvalidHomeLoanAmount });
            }

            if (Term <= 0)
            {
                _businessRules.Add(new BusinessRule() { Name = "Term", Description = ValidationMessages.InvalidHomeLoanTerm });
            }

            if (InterestRatePercentage < 0)
            {
                _businessRules.Add(new BusinessRule() { Name = "Interest Rate", Description = ValidationMessages.InvalidHomeLoanInterestRate });
            } 

            /* Other rules here might include checks for Loan to Value ratios based on current value of the property and the size of the loan principal */
        }
    }
}
