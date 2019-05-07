namespace YourMoney.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;

    using Microsoft.AspNetCore.Mvc;

    using YourMoney.Data;
    using YourMoney.Services.Contracts;
    using YourMoney.Web.Controllers.Base;
    using YourMoney.Web.Models.Banks;

    public class BanksController : BaseController
    {
        private readonly IBanksService banksService;
        private readonly ApplicationDbContext db;

        public BanksController(IBanksService banksService, ApplicationDbContext db)
        {
            this.banksService = banksService;
            this.db = db;
        }

        public IActionResult All()
        {
            //var banks = this.banksService.All<BankViewModel>().ToList();

            //var allBanks = this.banksService.AllBanks().Select(vm => new BankViewModel
            //{
            //    BankName = vm.Name,
            //});

            //var banks = Mapper.Map<IList<BankViewModel>>(allBanks);

            //var banks = this.db.Banks.Select(vm => new BankViewModel
            //{
            //    BankName = vm.Name
            //})
            //.ToList();

            //var allBanksViewModel = new AllBanksViewModel
            //{
            //    Banks = banks
            //};

            //return View(allBanksViewModel);
            return this.View();
        }
    }
}