namespace YourMoney.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    using YourMoney.Common;

    public enum DepositType
    {
        [Display(Name = GlobalConstants.TermDeposit)]
        TermDeposit = 0,

        [Display(Name = GlobalConstants.FlexibleDeposit)]
        FlexibleDeposit = 1,

        [Display(Name = GlobalConstants.AdvancePaymentInterestDeposit)]
        AdvancePaymentInterestDeposit = 2
    }
}