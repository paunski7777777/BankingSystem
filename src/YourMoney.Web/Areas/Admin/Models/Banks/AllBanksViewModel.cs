namespace YourMoney.Web.Areas.Admin.Models.Banks
{
    using System.Collections.Generic;

    public class AllBanksViewModel
    {
        public IEnumerable<BankViewModel> Banks { get; set; }
    }
}