namespace YourMoney.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    using YourMoney.Common;

    public enum DepositFor
    {
        [Display(Name = GlobalConstants.NoMatter)]
        NoMatter = 0,

        [Display(Name = GlobalConstants.Individuals)]
        Individuals = 1,

        [Display(Name = GlobalConstants.Retirees)]
        Retirees = 2,

        [Display(Name = GlobalConstants.Children)]
        Children = 3,
    }
}