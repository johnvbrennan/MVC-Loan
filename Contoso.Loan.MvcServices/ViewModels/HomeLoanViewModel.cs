using System;
using System.ComponentModel.DataAnnotations;

namespace Contoso.Loan.MvcServices.ViewModels
{
    public class HomeLoanViewModel
    {
        [Required(ErrorMessage = "Please enter the loan amount.")]
        [Range(1000,1000000, ErrorMessage = "Loan amount must be between 1,000 and 1000,000.")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "Please enter the term of the loan.")]
        [Range(1, 35, ErrorMessage = "Term of loan must be between 1 and 35 years")]
        public int Term { get; set; }

        [Required(ErrorMessage = "Please enter the interest rate.")]
        [Display(Name="Rate")]
        public decimal InterestRate { get; set; }

        [Required(ErrorMessage = "Please enter the first repayment date.")]
        [DataType(DataType.Date)]
        [Display(Name="First Repayment Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FirstRepaymentDate { get; set; }
    } 
}
