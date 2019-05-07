namespace YourMoney.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    using YourMoney.Common;

    public enum InterestPayment
    {
        [Display(Name = GlobalConstants.NoMatter)]
        NoMatter = 0,

        [Display(Name = GlobalConstants.OnMaturity)]
        OnMaturity = 1,

        [Display(Name = GlobalConstants.InAdvance)]
        InAdvance = 2,

        [Display(Name = GlobalConstants.Monthly)]
        Monthly = 3,

        [Display(Name = GlobalConstants.EndOfPeriod)]
        EndOfPeriod = 4,
    }
}