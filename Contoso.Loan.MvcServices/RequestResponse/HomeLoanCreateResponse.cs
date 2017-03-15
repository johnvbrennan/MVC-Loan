using System;
using System.Collections.Generic;
using Contoso.Loan.Domain.Enums;
using Contoso.Loan.Domain.Messages;
using Contoso.Loan.MvcServices.ViewModels;

namespace Contoso.Loan.MvcServices.RequestResponse
{
    public class HomeLoanCreateResponse
    {
        public HomeLoanCreateResponse()
        {
            ServiceStatus = new ServiceStatus();
            ValidationMessages = new List<LoanValidationMessage>();
        }
        public LoanSummaryViewModel LoanSummary { get; set; }

        public Guid LoanId { get; set; }

        public ServiceStatus ServiceStatus { get; set; }
        public List<LoanValidationMessage> ValidationMessages { get; set; }
    } 
}
