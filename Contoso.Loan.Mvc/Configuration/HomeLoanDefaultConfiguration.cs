namespace Contoso.Loan.Mvc.Configuration
{
    public class HomeLoanDefaultConfiguration : ILoanDefaultConfiguration
    {
        public decimal DefaultInterestRate
        {
            get { return AppSettings.DefaultInterestRate; }
        }

        public int DefaultLoanAmount
        {
            get { return AppSettings.DefaultLoanAmount; }
        }

        public int DefaultLoanTerm
        {
            get { return AppSettings.DefaultLoanTerm; }
        }
    }
}