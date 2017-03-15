using Microsoft.VisualStudio.TestTools.UnitTesting;
using Contoso.Loan.Domain.Enums;
using Contoso.Loan.Domain.Loans;
using Contoso.Loan.Domain.Messages;

namespace Contoso.Loan.MvcServices.Tests
{
    [TestClass]
    public class HomeLoanTests
    {
        [TestMethod]
        public void IsValid_WhenInterestRateIsLessThanZero_ReturnsBrokenBusinessRule()
        {
            // Arrange
            var loan = new HomeLoan(1000, 3, -2.5m, CurrencyType.Euro);

            // Act
            var response = loan.IsValidLoan();
            var brokenRules = loan.GetBrokenBusinessRulesOnThisLoan();

            // Assert
            Assert.IsFalse(response, "Expected loan to be invalid.");
            Assert.AreEqual(1, brokenRules.Count, "Expected a single business rule to be violated.");
            Assert.AreEqual(ValidationMessages.InvalidHomeLoanInterestRate, brokenRules[0].Description);
        }

        [TestMethod]
        public void IsValid_WhenAmounIsLessThanOrEqualToZero_ReturnsBrokenBusinessRule()
        {
            // Arrange
            var loan = new HomeLoan(0, 3, 2.5m, CurrencyType.Euro);

            // Act
            var response = loan.IsValidLoan();
            var brokenRules = loan.GetBrokenBusinessRulesOnThisLoan();

            // Assert
            Assert.IsFalse(response, "Expected loan state to be invalid.");
            Assert.AreEqual(1, brokenRules.Count, "Expected a single business rule to be violated.");
            Assert.AreEqual(ValidationMessages.InvalidHomeLoanAmount, brokenRules[0].Description);
        }

        [TestMethod]
        public void IsValid_WhenTermIsLessThan1Year_ReturnsBrokenBusinessRule()
        {
            // Arrange
            var loan = new HomeLoan(1000, 0, 2.5m, CurrencyType.Euro);

            // Act
            var response = loan.IsValidLoan();
            var brokenRules = loan.GetBrokenBusinessRulesOnThisLoan();

            // Assert
            Assert.IsFalse(response, "Expected loan state to be invalid.");
            Assert.AreEqual(1, brokenRules.Count, "Expected a single business rule to be violated.");
            Assert.AreEqual(ValidationMessages.InvalidHomeLoanTerm, brokenRules[0].Description);
        }

        [TestMethod]
        public void IsValid_WhenLoanIsValid_ReturnsNoBrokenBusinessRule()
        {
            // Arrange
            var loan = new HomeLoan(1000, 1, 2.5m, CurrencyType.Euro);

            // Act
            var response = loan.IsValidLoan();
            var brokenRules = loan.GetBrokenBusinessRulesOnThisLoan();

            // Assert
            Assert.IsTrue(response, "Expected loan state to be valid.");
            Assert.AreEqual(0, brokenRules.Count, "Expected no business rule to be violated."); 
        }

        [TestMethod]
        public void HomeLoanConstructor_WhenInitializedByConstructor_PropertiesAreSetCorrectly()
        {
            // Arrange
            decimal loanAmount = 1000;
            decimal loanInterestRate = 3.5m;
            int loanTerm = 5;
            CurrencyType loanCurrency = CurrencyType.UsDollars;


            // Act
            var loan = new HomeLoan(loanAmount, loanTerm, loanInterestRate, loanCurrency);

            // Assert
            Assert.AreEqual(loanAmount, loan.Principal, "Loan amount not set correctly by constructor");
            Assert.AreEqual(loanTerm, loan.Term, "Loan term not set correctly by constructor");
            Assert.AreEqual(loanInterestRate, loan.InterestRatePercentage, "Loan interest rate not set correctly by constructor");
            Assert.AreEqual(loanCurrency, loan.Currency, "Loan currency type not set correctly by constructor");
        }

    }
}
