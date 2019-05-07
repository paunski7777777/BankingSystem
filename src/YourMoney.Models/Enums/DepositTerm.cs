namespace YourMoney.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    using YourMoney.Common;

    public enum DepositTerm
    {
        [Display(Name = GlobalConstants.OneMonth)]
        OneMonth = 0,

        [Display(Name = GlobalConstants.ThreeMonths)]
        ThreeMonths = 1,

        [Display(Name = GlobalConstants.SixMonths)]
        SixMonths = 2,

        [Display(Name = GlobalConstants.NineMonths)]
        NineMonths = 3,

        [Display(Name = GlobalConstants.TwelveMonths)]
        TwelveMonths = 4,

        [Display(Name = GlobalConstants.EighteenMonths)]
        EighteenMonths = 5,

        [Display(Name = GlobalConstants.TwentyFourMonths)]
        TwentyFourMonths = 6,

        [Display(Name = GlobalConstants.ThirtySixMonths)]
        ThirtySixMonths = 7,

        [Display(Name = GlobalConstants.FortyEightMonths)]
        FortyEightMonths = 8,

        [Display(Name = GlobalConstants.SixtyMonths)]
        SixtyMonths = 9
    }
}