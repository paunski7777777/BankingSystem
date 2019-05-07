namespace YourMoney.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    using YourMoney.Common;

    public enum InterestCapitalize
    {
        [Display(Name = GlobalConstants.Yes)]
        Yes = 1,

        [Display(Name = GlobalConstants.No)]
        No = 2
    }
}