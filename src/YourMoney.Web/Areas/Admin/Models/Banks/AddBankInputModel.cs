namespace YourMoney.Web.Areas.Admin.Models.Banks
{
    using System.ComponentModel.DataAnnotations;

    using YourMoney.Common;

    public class AddBankInputModel
    {
        [Required]
        [Display(Name = GlobalConstants.BankDisplayName)]
        public string Name { get; set; }
    }
}