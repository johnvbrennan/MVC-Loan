using System;
using System.Web.Mvc;
using Contoso.Loan.Domain.Enums;
using Contoso.Loan.Mvc.Configuration;
using Contoso.Loan.MvcServices.Interfaces;
using Contoso.Loan.MvcServices.RequestResponse;
using Contoso.Loan.MvcServices.ViewModels;

namespace Contoso.Loan.Mvc.Controllers
{
    public class LoanController : Controller
    {
        private readonly IHomeLoanService _homeLoanService = null;
        private readonly ILoanDefaultConfiguration _loanDefaultConfiguration = null;
      
        public LoanController(IHomeLoanService homeLoanService, ILoanDefaultConfiguration loanDefaultConfiguration)
        {
            _homeLoanService = homeLoanService;
            _loanDefaultConfiguration = loanDefaultConfiguration;
        }

        [HttpGet]
        public ActionResult Index(bool? noDefault)
        {
            if (noDefault.HasValue && noDefault.Value)
            {
                return View();
            }

            HomeLoanViewModel defaultViewModel = new HomeLoanViewModel
            {
                Amount = _loanDefaultConfiguration.DefaultLoanAmount,
                InterestRate = _loanDefaultConfiguration.DefaultInterestRate,
                Term = _loanDefaultConfiguration.DefaultLoanTerm,
                FirstRepaymentDate = DateTime.Now.AddDays(1)
            };

            return View(defaultViewModel);
            
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Index(HomeLoanViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var request = new HomeLoanCreateRequest()
            {
                LoanViewModel = viewModel
            };

            var response = _homeLoanService.CreateHomeLoan(request);

            if (response.ServiceStatus != ServiceStatus.Success)
            {
                foreach (var message in response.ValidationMessages)
                {
                    ViewData.ModelState.AddModelError("ServerError", message.Message);
                }

                return View(viewModel);
            }

            TempData["LoanSummary"] = response.LoanSummary;
            return RedirectToAction("LoanDetails");
        }

        [HttpGet]
        public ActionResult LoanDetails()
        {
            LoanSummaryViewModel viewModel = TempData["LoanSummary"] as LoanSummaryViewModel;

            return View(viewModel);
        }
    }
}