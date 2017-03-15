using Contoso.Loan.Domain.Requests;
using Contoso.Loan.Domain.Responses;

namespace Contoso.Loan.Services
{
    public interface ILoanService
    {
        HomeLoanResponse NewHomeLoan(HomeLoanServiceRequest serviceRequest);
    }
}
