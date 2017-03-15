using System;
using System.Linq;
using Contoso.Loan.Domain.Enums;
using Contoso.Loan.Domain.Loans;
using Contoso.Loan.Domain.Requests;
using Contoso.Loan.Domain.Responses;  

namespace Contoso.Loan.Services
{
    public class LoanService : ILoanService
    {
        public HomeLoanResponse NewHomeLoan(HomeLoanServiceRequest request)
        {
            var response = new HomeLoanResponse();
 
            var newLoan = new HomeLoan(request.Amount, request.Term, request.InterestRate, request.Currency);

            if (newLoan.IsValidLoan())
            { 
                response.Loan = newLoan;
                response.PaymentPlan = newLoan.GetRepaymentSchedule(request.FirstRepaymentDate).ToList();
                response.TotalRepaymentAmount = (Decimal.Round(newLoan.GetRepaymentAmount(), 2) * request.Term * 12);
                response.Status = ServiceStatus.Success;
            }
            else
            {
                response.Status = ServiceStatus.Failure;
                response.BrokenBusinessRules = newLoan.GetBrokenBusinessRulesOnThisLoan();
            }

            return response;
        }
    }
}
