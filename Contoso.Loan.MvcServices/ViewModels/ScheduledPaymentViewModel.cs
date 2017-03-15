using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Loan.MvcServices.ViewModels
{  
    public class ScheduledPaymentViewModel
    {
        public string PaymentDate { get; set; }
        public string PrinciplePaidAmount { get; set; }
        public string InterestPaidAmount { get; set; }
        public string RemainingBalance { get; set; }
        public string TotalPaid { get; set; }
    }
}
