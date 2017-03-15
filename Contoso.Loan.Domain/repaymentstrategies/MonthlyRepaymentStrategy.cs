using System;
using System.Collections.Generic;
using Contoso.Loan.Domain;
using Contoso.Loan.Domain.Interfaces;
using Contoso.Loan.Domain.Loans;
using Contoso.Loan.Domain.Responses;

namespace Contoso.Loan.Domain.RepaymentStrategies
{ 
    public class MonthlyRepaymentStrategy : IRepaymentStrategy
    {
        private const int MonthsInYear = 12;

        public IEnumerable<IPayment> GetRepaymentSchedule(DateTime firstPaymentDate, decimal principal, decimal interestRatePercentage, int term)
        {
            var repayments = new List<MonthlyRepayment>();

            int numberOfRepayments = (term * MonthsInYear);
            var monthlyRepayment = GetRepaymentsFor(principal, interestRatePercentage, term); 
            var balance = principal;
            var monthlyInterestRate = interestRatePercentage / (MonthsInYear * 100);
             
            for(int index = 0; index < numberOfRepayments;index++)
            {
                var interestAmountPaid  = balance * monthlyInterestRate;
                var principleAmountPaid = monthlyRepayment - interestAmountPaid;

                balance = balance - principleAmountPaid;

                var payment = new MonthlyRepayment(firstPaymentDate, principleAmountPaid, interestAmountPaid, balance);
                repayments.Add(payment);

                if (balance < 0) break;

                // Advance to the next schedule payment date in the series 
                firstPaymentDate = firstPaymentDate.AddMonths(1);
            }

            return repayments;
        }

        /// <summary>
        /// Calculate the monthly repayments for the loan based on the pr
        /// </summary> 
        /// <param name="loan">The loan to determine repayment for</param>
        /// <returns></returns>
        public decimal GetRepaymentsFor(decimal principal, decimal interestRatePercentage, int term)
        {
            if (interestRatePercentage < 0) throw new ArgumentOutOfRangeException("Interest rate must be greater than or equal to 0.");

            int numberOfRepayments = (term * MonthsInYear);
            double periodicInterestRate = Convert.ToDouble(interestRatePercentage / 100);

            //
            // Loan amortization annuity formula sourced from: https://en.wikipedia.org/wiki/Amortization_calculator
            //
            double monthlyRepaymentAmount = periodicInterestRate > 0
                ? CalculateRepaymentWhenInterestRateGreaterThanZero(principal, periodicInterestRate, numberOfRepayments)
                : CalculateRepaymentWhenInterestRateIsZero(principal, numberOfRepayments);

            return Convert.ToDecimal(monthlyRepaymentAmount);
        }

        private double CalculateRepaymentWhenInterestRateGreaterThanZero(decimal principal, double periodicInterestRate, int numberOfRepayments)
        {
            return Convert.ToDouble(principal) *
                   (Math.Pow((1 + periodicInterestRate / MonthsInYear), numberOfRepayments) * periodicInterestRate) /
                   (MonthsInYear * (Math.Pow((1 + periodicInterestRate / MonthsInYear), numberOfRepayments) - 1));
        }

        private double CalculateRepaymentWhenInterestRateIsZero(decimal principal, int numberOfRepayments)
        {
            return Convert.ToDouble(principal)/numberOfRepayments;
        }
    }
}
