namespace YourMoney.Web.Areas.Admin.Models.Banks
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using YourMoney.Common;
    using YourMoney.Web.Areas.Admin.Models.Deposits;

    public class BankDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = GlobalConstants.BankDisplayName)]
        public string Name { get; set; }

        public IEnumerable<DepositBankDetailsViewModel> Deposits { get; set; }
    }
}