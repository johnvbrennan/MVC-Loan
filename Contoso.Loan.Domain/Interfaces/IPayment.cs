using System;

namespace Contoso.Loan.Domain.Interfaces
{
    public interface IPayment
    {
        DateTime PaymentDate { get; set; }
        Decimal InterestPaidAmount { get; set; }
        Decimal PrincipalPaidAmount { get; set; }
        Decimal RemainingBalance { get; set; }
    }
}
