using System.Collections.Generic;
using Contoso.Loan.Domain.Interfaces;
using Contoso.Loan.MvcServices.ViewModels;

namespace Contoso.Loan.MvcServices.Extensions
{
    public static class PaymentPlanExtensions
    {
        public static List<ScheduledPaymentViewModel> PaymentPlanToScheduledPaymentPlanViewModel(this List<IPayment> payments)
        {
            var result = new List<ScheduledPaymentViewModel>();

            foreach (var p in payments)
            {
                result.Add(new ScheduledPaymentViewModel()
                {
                    InterestPaidAmount = p.InterestPaidAmount.ToString("C"),
                    PrinciplePaidAmount = p.PrincipalPaidAmount.ToString("C"),
                    PaymentDate = p.PaymentDate.ToShortDateString(),
                    RemainingBalance = p.RemainingBalance.ToString("C"),
                    TotalPaid = (p.InterestPaidAmount + p.PrincipalPaidAmount).ToString("C")
                });
            }

            return result;
        }
    }
}
