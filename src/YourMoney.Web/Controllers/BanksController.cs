namespace YourMoney.Web.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;

    using YourMoney.Services.Contracts;
    using YourMoney.Web.Controllers.Base;
    using YourMoney.Web.Models.Banks;

    public class BanksController : BaseController
    {
        private readonly IBanksService banksService;

        public BanksController(IBanksService banksService)
        {
            this.banksService = banksService;
        }

        public IActionResult All()
        {
            var banks = this.banksService.All<BankViewModel>().ToList();

            var allBanksViewModel = new AllBanksViewModel
            {
                Banks = banks
            };

            return this.View(allBanksViewModel);
        }
    }
}