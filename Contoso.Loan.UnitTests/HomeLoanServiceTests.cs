using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;
using Contoso.Loan.Domain.Messages;
using Contoso.Loan.Domain.Requests;
using Contoso.Loan.Domain.Responses;
using Contoso.Loan.MvcServices.Services;
using Contoso.Loan.Services;
using Contoso.Loan.MvcServices.RequestResponse;
using Contoso.Loan.Domain.Enums;
using Contoso.Loan.Domain.Interfaces;
using Contoso.Loan.Domain.Loans;
using Contoso.Loan.Domain.Rules;

namespace Contoso.Loan.MvcServices.Tests
{
    [TestClass]
    public class HomeLoanServiceTests
    {
        private static Fixture _fixture;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _fixture = new Fixture();
        }

        [TestMethod]
        public void CreateHomeLoan_WhenInterestRateIsLessThanZero_ReturnsServiceStatusFailure()
        {
            //Arrange  
            var mockLoanServiceResponse = new HomeLoanResponse()
            {
                BrokenBusinessRules = new List<BusinessRule>() { new BusinessRule() { Description = ValidationMessages.InvalidHomeLoanInterestRate } },
                Status = ServiceStatus.Failure
            };

            var homeLoanCreateRequest = _fixture.Build<HomeLoanCreateRequest>().Create();

            var mockLoanService = new Mock<ILoanService>();
            mockLoanService.Setup(s => s.NewHomeLoan(It.IsAny<HomeLoanServiceRequest>())).Returns(mockLoanServiceResponse);

            var homeLoanService = new HomeLoanService(mockLoanService.Object);

            //Act
            var response = homeLoanService.CreateHomeLoan(homeLoanCreateRequest);

            //Assert
            var expectedStatus = ServiceStatus.Failure;
            Assert.AreEqual(expectedStatus, response.ServiceStatus);
            Assert.AreEqual(1, response.ValidationMessages.Count);
            Assert.AreEqual(ValidationMessages.InvalidHomeLoanInterestRate, response.ValidationMessages[0].Message);
        }

        [TestMethod]
        public void CreateHomeLoan_WhenValidLoanRequestCriteriaSupplied_ReturnsServiceStatusSuccessWithPaymentPlan()
        {
            //Arrange  
            var mockLoanServiceResponse = new HomeLoanResponse()
            { 
                Status = ServiceStatus.Success,
                InterestTotal = 100,
                Principle = 2000,
                Loan = _fixture.Build<HomeLoan>().Create(),
                PaymentPlan = new List<IPayment>() { _fixture.Build<MonthlyRepayment>().Create() }
            };

            var homeLoanCreateRequest = _fixture.Build<HomeLoanCreateRequest>().Create();

            var mockLoanService = new Mock<ILoanService>();
            mockLoanService.Setup(s => s.NewHomeLoan(It.IsAny<HomeLoanServiceRequest>())).Returns(mockLoanServiceResponse);

            var homeLoanService = new HomeLoanService(mockLoanService.Object);

            //Act
            var response = homeLoanService.CreateHomeLoan(homeLoanCreateRequest);

            //Assert
            var expectedStatus = ServiceStatus.Success;
            Assert.AreEqual(expectedStatus, response.ServiceStatus);
            Assert.AreEqual(0, response.ValidationMessages.Count);
            Assert.IsNotNull(response.LoanSummary, "Expected to receive details of payment plan for the loan");
            Assert.AreEqual(1, response.LoanSummary.ScheduledPayments.Count, "Expected number of scheduled repayments to be 1");
        }

        [TestMethod]
        public void CreateHomeLoan_WhenLoanTermIsLessThanOrEqualToZero_ReturnsServiceStatusFailure()
        {
            //Arrange  
            var mockLoanServiceResponse = new HomeLoanResponse()
            {
                BrokenBusinessRules = new List<BusinessRule>() { new BusinessRule() {Description = ValidationMessages.InvalidHomeLoanTerm} },
                Status = ServiceStatus.Failure
            };

            var homeLoanCreateRequest = _fixture.Build<HomeLoanCreateRequest>().Create();

            var mockLoanService = new Mock<ILoanService>();
            mockLoanService.Setup(s => s.NewHomeLoan(It.IsAny<HomeLoanServiceRequest>())).Returns(mockLoanServiceResponse);

            var homeLoanService = new HomeLoanService(mockLoanService.Object);  

            //Act
            var response = homeLoanService.CreateHomeLoan(homeLoanCreateRequest);

            //Assert
            var expectedStatus = ServiceStatus.Failure;
            Assert.AreEqual(expectedStatus, response.ServiceStatus);
            Assert.AreEqual(1, response.ValidationMessages.Count);
            Assert.AreEqual(ValidationMessages.InvalidHomeLoanTerm, response.ValidationMessages[0].Message);
        }


        [TestMethod]
        public void CreateHomeLoan_WhenPrincipalAmountIsLessThanOrEqualToZero_ReturnsServiceStatusFailure()
        {
            //Arrange  
            var mockLoanServiceResponse = new HomeLoanResponse()
            {
                BrokenBusinessRules = new List<BusinessRule>() { new BusinessRule() { Description = ValidationMessages.InvalidHomeLoanAmount } },
                Status = ServiceStatus.Failure
            };

            var homeLoanCreateRequest = _fixture.Build<HomeLoanCreateRequest>().Create();

            var mockLoanService = new Mock<ILoanService>();
            mockLoanService.Setup(s => s.NewHomeLoan(It.IsAny<HomeLoanServiceRequest>())).Returns(mockLoanServiceResponse);

            var homeLoanService = new HomeLoanService(mockLoanService.Object);

            //Act
            var response = homeLoanService.CreateHomeLoan(homeLoanCreateRequest);

            //Assert
            var expectedStatus = ServiceStatus.Failure;
            Assert.AreEqual(expectedStatus, response.ServiceStatus);
            Assert.AreEqual(1, response.ValidationMessages.Count);
            Assert.AreEqual(ValidationMessages.InvalidHomeLoanAmount, response.ValidationMessages[0].Message);
        }
    }
}
