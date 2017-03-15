using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;
using Contoso.Loan.Mvc.Controllers;
using Contoso.Loan.MvcServices.Interfaces;
using Contoso.Loan.MvcServices.ViewModels;
using Contoso.Loan.Mvc.Configuration;

namespace Contoso.Loan.Web.Tests.Controllers
{
    [TestClass]
    public class LoanControllerTest
    {
        private static Fixture _fixture;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _fixture = new Fixture();
        }

        [TestMethod]
        public void Index_WhenNullPassedtToIndex_ShouldReturnUseConfigurationDefaultIndexView()
        {
            //Arrange
            const int amount = 2000;
            const decimal rate = 3.5m;
            const int term = 2;
            var mockHomeLoanService = new Mock<IHomeLoanService>();
            var mockLoanDefaultConfiguration = new Mock<ILoanDefaultConfiguration>();
            mockLoanDefaultConfiguration.SetupGet(x => x.DefaultLoanAmount).Returns(amount);
            mockLoanDefaultConfiguration.SetupGet(x => x.DefaultInterestRate).Returns(rate);
            mockLoanDefaultConfiguration.SetupGet(x => x.DefaultLoanTerm).Returns(term);
            bool? noDefault = null;

            //Act
            var controller = new LoanController(mockHomeLoanService.Object, mockLoanDefaultConfiguration.Object);
            var actual = controller.Index(noDefault) as ViewResult;

            //Assert
            Assert.IsNotNull(actual, "View result cannot be null");
            Assert.AreEqual(amount, ((HomeLoanViewModel)actual.Model).Amount, "Home Loan default amount not set correctly");
            Assert.AreEqual(term, ((HomeLoanViewModel)actual.Model).Term, "Home Loan default term not set correctly");
            Assert.AreEqual(rate, ((HomeLoanViewModel)actual.Model).InterestRate, "Home Loan default interest rate not set correctly");
        }

        [TestMethod]
        public void Index_WhenTruePassedtToIndex_ShouldReturnDefaultIndexView()
        {
            //Arrange
            const int amount = 2000;
            const decimal rate = 3.5m;
            const int term = 2;
            var mockHomeLoanService = new Mock<IHomeLoanService>();
            var mockLoanDefaultConfiguration = new Mock<ILoanDefaultConfiguration>();
            mockLoanDefaultConfiguration.SetupGet(x => x.DefaultLoanAmount).Returns(amount);
            mockLoanDefaultConfiguration.SetupGet(x => x.DefaultInterestRate).Returns(rate);
            mockLoanDefaultConfiguration.SetupGet(x => x.DefaultLoanTerm).Returns(term);
            bool? noDefault = true;

            //Act
            var controller = new LoanController(mockHomeLoanService.Object, mockLoanDefaultConfiguration.Object);
            var actual = controller.Index(noDefault) as ViewResult;

            //Assert
            Assert.IsNotNull(actual, "View result cannot be null");
            Assert.IsNull((actual.Model as HomeLoanViewModel), "Expect view model to be null");
        }
    }
}
