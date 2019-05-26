using System.ComponentModel.DataAnnotations;
using YourMoney.Common;

namespace YourMoney.Web.Areas.Admin.Models.Deposits
{
    public class DepositBankDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = GlobalConstants.DepositDisplayName)]
        public string Name { get; set; }
    }
}