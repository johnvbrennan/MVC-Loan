using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Contoso.Loan.Domain.Enums;
using Contoso.Loan.Domain.Loans; 

namespace Contoso.Loan.MvcServices.Tests
{
    /// <summary>
    /// Summary description for RepaymentStrategyTests
    /// </summary>
    [TestClass]
    public class RepaymentStrategyTests
    {
        /// <summary>
        /// Test that the calculator returns correct result for known fixed rate loan scenario.
        /// Scenario at: http://www.investopedia.com/university/mortgage/mortgage4.asp 
        /// Principal: 100,000
        /// Interest:  6%
        /// Term:      30years
        /// Monthly Repayments: 599.95
        /// </summary>
        [TestMethod]
        public void GetRepaymentsFor_WhenPrincipalIs100kAndTermIs30YearsAndInterestIs6Percent_MonthlyRepaymentsAre599_55()
        {
            // Arrange
            const decimal expectedMonthlyPayment = 599.55m;

            var loan = new HomeLoan(100000, 30, 6, CurrencyType.Euro); 

            // Act
            var actualMonthlyPayment = Decimal.Round(loan.GetRepaymentAmount(), 2);

            // Assert
            Assert.AreEqual(expectedMonthlyPayment, actualMonthlyPayment);
        }

        /// <summary>
        /// Test that calculator returns correct result for interest rate of 0%. 
        /// Principal: 2,400
        /// Interest:  0%
        /// Term:      2 years
        /// Montly Repayments: 100
        /// </summary>
        [TestMethod]
        public void GetRepaymentsFor_WhenPrincipalIs1000AndTermIs30YearsAndInterestIsZeroPercent_MonthlyRepaymentsAre_100()
        {
            // Arrange
            const decimal expectedMonthlyPayment = 100m;

            var loan = new HomeLoan(2400, 2, 0, CurrencyType.Euro); 

            // Act
            var actualMonthlyPayment = loan.GetRepaymentAmount();

            // Assert
            Assert.AreEqual(expectedMonthlyPayment, actualMonthlyPayment);
        }
    }
}
