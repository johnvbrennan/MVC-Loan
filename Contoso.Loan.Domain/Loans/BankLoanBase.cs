using System;
using System.Collections.Generic;
using Contoso.Loan.Domain.Enums;
using Contoso.Loan.Domain.Exceptions;
using Contoso.Loan.Domain.Interfaces;
using Contoso.Loan.Domain.Rules;

namespace Contoso.Loan.Domain.Loans
{
    /// <summary>
    /// Base class that all types of loans will derive from
    /// </summary> 
    public abstract class BankLoanBase
    {
        protected IRepaymentStrategy _repaymentStrategy = null;
        protected List<BusinessRule> _businessRules = new List<BusinessRule>();

        protected BankLoanBase(decimal principal, int term, decimal interestRatePercentage, CurrencyType currency)
        {
            Id = Guid.NewGuid(); 
            Currency = currency;
            Principal = principal;
            Term = term;
            InterestRatePercentage = interestRatePercentage;
            _repaymentStrategy = CreateRepaymentStrategy();
        }

        public Guid Id { get; } 
        public CurrencyType Currency { get; set; } 
        public decimal Principal { get; }
        public int Term { get; }
        public decimal InterestRatePercentage { get; }

        private void ClearBrokenBusinessRulesOnThisLoan()
        {
            _businessRules.Clear();
        }
        private void CheckRepaymentStrategyIsConfiguredForLoan()
        {
            if (_repaymentStrategy == null)
            {
                throw new NoRepaymentStrategyConfiguredException("No payment strategy has been configured for this loan.");
            }
        }

        /// <summary>
        /// This template method will be implemented by derived loan classes. It will apply business rule validation
        /// specific to the derived loan. Any failed business rules will be added to the _businessRules collection
        /// in the base class.
        /// </summary>
        protected abstract void CheckForBrokenBusinessRulesOnThisLoan();

        /// <summary>
        /// This template method will be implementd by derived loan classes. They will use this to set the repayment
        /// strategy that applies to their loan type.
        /// </summary>
        /// <returns></returns>
        protected abstract IRepaymentStrategy CreateRepaymentStrategy();
        
        public bool IsValidLoan()
        {
            ClearBrokenBusinessRulesOnThisLoan();
            CheckForBrokenBusinessRulesOnThisLoan();
            return _businessRules.Count == 0;
        }

        public IEnumerable<IPayment> GetRepaymentSchedule(DateTime firstPaymentDate)
        {
            CheckRepaymentStrategyIsConfiguredForLoan();

            return _repaymentStrategy.GetRepaymentSchedule(firstPaymentDate, Principal, InterestRatePercentage, Term);
        }

        public decimal GetRepaymentAmount()
        {
            CheckRepaymentStrategyIsConfiguredForLoan();

            return _repaymentStrategy.GetRepaymentsFor(Principal, InterestRatePercentage, Term);
        }

        public List<BusinessRule> GetBrokenBusinessRulesOnThisLoan()
        {
            return _businessRules;
        }
    }
}
