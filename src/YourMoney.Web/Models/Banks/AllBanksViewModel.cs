namespace YourMoney.Web.Models.Banks
{
    using System.Collections.Generic;

    public class AllBanksViewModel
    {
        public IEnumerable<BankViewModel> Banks { get; set; }
    }
}