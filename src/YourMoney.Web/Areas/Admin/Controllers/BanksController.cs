namespace YourMoney.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using YourMoney.Common;
    using YourMoney.Services.Contracts;
    using YourMoney.Web.Areas.Admin.Controllers.Base;
    using YourMoney.Web.Areas.Admin.Models.Banks;
    using YourMoney.Web.Models;

    public class BanksController : AdminBaseController
    {
        private readonly IBanksService banksService;

        public BanksController(IBanksService banksService)
        {
            this.banksService = banksService;
        }

        public IActionResult Add() => this.View();

        [HttpPost]
        public IActionResult Add(AddBankInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var bankExists = this.banksService.ExistsByName(model.Name);
            if (bankExists)
            {
                var errorViewModel = new ErrorViewModel
                {
                    ErrorMessage = string.Format(ErrorMessages.BankAlreadyExitstMessage, model.Name)
                };

                return this.View(viewName: GlobalConstants.ErrorViewName, model: errorViewModel);
            }

            this.banksService.Add(model.Name);

            var routeValues = new { Area = GlobalConstants.EmptyArea };

            return this.RedirectToAction(nameof(All));
        }

        public IActionResult Delete(int id)
        {
            var bankExits = this.banksService.ExistsById(id);
            if (!bankExits)
            {
                var errorViewModel = new ErrorViewModel
                {
                    ErrorMessage = ErrorMessages.InvalidBankIdMessage
                };

                return this.View(viewName: GlobalConstants.ErrorViewName, model: errorViewModel);
            }

            var bank = this.banksService.GetById<BankViewModel>(id);

            return this.View(bank);
        }

        [HttpPost]
        public IActionResult Delete(BankViewModel model)
        {
            this.banksService.Remove(model.Id);

            return this.RedirectToAction(nameof(All));
        }

        public IActionResult Edit(int id)
        {
            var bankExits = this.banksService.ExistsById(id);
            if (!bankExits)
            {
                var errorViewModel = new ErrorViewModel
                {
                    ErrorMessage = string.Format(ErrorMessages.InvalidBankIdMessage, id)
                };

                return this.View(viewName: GlobalConstants.ErrorViewName, model: errorViewModel);
            }


            var bank = this.banksService.GetById<BankViewModel>(id);

            return this.View(bank);
        }

        [HttpPost]
        public IActionResult Edit(BankViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.banksService.Edit(model.Id, model.Name);

            return this.RedirectToAction(nameof(All));
        }

        public IActionResult Details(int id)
        {
            var bankExists = this.banksService.ExistsById(id);
            if (!bankExists)
            {
                var errorViewModel = new ErrorViewModel
                {
                    ErrorMessage = string.Format(ErrorMessages.InvalidBankIdMessage, id)
                };

                return this.View(viewName: GlobalConstants.ErrorViewName, model: errorViewModel);
            }

            var bankDetailsViewModel = this.banksService.GetById<BankDetailsViewModel>(id);

            return this.View(bankDetailsViewModel);
        }

        public IActionResult All()
        {
            var banks = this.banksService.All<BankViewModel>();

            var banksViewModel = new AllBanksViewModel
            {
                Banks = banks
            };

            return this.View(banksViewModel);
        }
    }
}