namespace YourMoney.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    using YourMoney.Common;

    public enum InterestType
    {
        [Display(Name = GlobalConstants.NoMatter)]
        NoMatter = 0,

        [Display(Name = GlobalConstants.Fixed)]
        Fixed = 1,

        [Display(Name = GlobalConstants.Variable)]
        Variable = 2,
    }
}