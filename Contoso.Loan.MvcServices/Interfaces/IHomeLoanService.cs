using Contoso.Loan.MvcServices.RequestResponse;

namespace Contoso.Loan.MvcServices.Interfaces
{
    public interface IHomeLoanService
    {
        HomeLoanCreateResponse CreateHomeLoan(HomeLoanCreateRequest request); 
    }
}
