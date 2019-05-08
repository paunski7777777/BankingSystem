namespace YourMoney.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    using YourMoney.Common;

    public enum DepositType
    {
        [Display(Name = GlobalConstants.TermDeposit)]
        TermDeposit = 0
    }
}