using System;
using Contoso.Loan.Domain.Interfaces;

namespace Contoso.Loan.Domain.Responses
{
    public class MonthlyRepayment : IPayment
    {
        public MonthlyRepayment(DateTime paymentDate, decimal principalPaidAmount, decimal interestPaidAmount, decimal remainingBalance)
        {
            PaymentDate = paymentDate;
            PrincipalPaidAmount = principalPaidAmount;
            InterestPaidAmount = interestPaidAmount;
            RemainingBalance = remainingBalance;
        }
        public decimal InterestPaidAmount
        {
            get;set;
        }

        public decimal PrincipalPaidAmount
        {
            get; set;
        }

        public decimal RemainingBalance
        {
            get;set;
        }

        public DateTime PaymentDate
        {
            get;set;
        } 
    }
}
