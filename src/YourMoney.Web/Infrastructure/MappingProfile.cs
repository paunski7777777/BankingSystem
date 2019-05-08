namespace YourMoney.Web.Infrastructure
{
    using AutoMapper;

    using YourMoney.Models;
    using YourMoney.Web.Models.Banks;
    using YourMoney.Web.Models.Deposits;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Bank, BankViewModel>();
            this.CreateMap<Deposit, BankDepositViewModel>();
            this.CreateMap<Deposit, Deposit>();
        }
    }
}