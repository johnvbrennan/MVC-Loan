using Microsoft.Extensions.Configuration;

namespace Contoso.Loan.Mvc.Configuration
{
    public class HomeLoanDefaultConfiguration : ILoanDefaultConfiguration
    {
        private readonly IConfiguration _configuration;

        public HomeLoanDefaultConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public decimal DefaultLoanAmount => decimal.Parse(_configuration["LoanDefaults:DefaultLoanAmount"] ?? "2000");

        public decimal DefaultInterestRate => decimal.Parse(_configuration["LoanDefaults:DefaultInterestRate"] ?? "3.5");

        public int DefaultLoanTerm => int.Parse(_configuration["LoanDefaults:DefaultLoanTerm"] ?? "1");
    }
}
