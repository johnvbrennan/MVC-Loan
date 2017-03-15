using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Loan.MvcServices.ViewModels;

namespace Contoso.Loan.MvcServices.RequestResponse
{
    public class HomeLoanCreateRequest
    {
        public HomeLoanViewModel LoanViewModel { get; set; }
    }
}
