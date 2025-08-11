using Microsoft.Extensions.Configuration;

namespace Contoso.Loan.Mvc.Configuration
{
    public static class AppSettings
    { 
        private static IConfiguration? _configuration;
        
        public static void Initialize(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static int DefaultLoanAmount
        {
            get
            {
                if (_configuration == null)
                    throw new InvalidOperationException("AppSettings not initialized. Call Initialize() first.");
                    
                string? value = _configuration["LoanDefaults:DefaultLoanAmount"];
                return int.Parse(value ?? "2000");
            }
        }

        public static int DefaultLoanTerm
        {
            get
            {
                if (_configuration == null)
                    throw new InvalidOperationException("AppSettings not initialized. Call Initialize() first.");
                    
                string? value = _configuration["LoanDefaults:DefaultLoanTerm"];
                return int.Parse(value ?? "1");
            }
        }

        public static decimal DefaultInterestRate
        {
            get
            {
                if (_configuration == null)
                    throw new InvalidOperationException("AppSettings not initialized. Call Initialize() first.");
                    
                string? value = _configuration["LoanDefaults:DefaultInterestRate"];
                return decimal.Parse(value ?? "3.5");
            }
        }
    }
}
