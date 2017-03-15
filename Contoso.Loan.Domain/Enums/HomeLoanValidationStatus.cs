namespace Contoso.Loan.Domain.Enums
{
    public enum HomeLoanValidationStatus
    {
        UnknownError,
        InvalidAmount,
        InvalidTerm,
        InvalidInterestRate,
        TermExceedsMaximum,
        LoanAmountExceedsMaximum
    }
}
