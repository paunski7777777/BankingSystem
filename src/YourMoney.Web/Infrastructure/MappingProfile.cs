namespace YourMoney.Web.Infrastructure
{
    using AutoMapper;

    using YourMoney.Models;
    using YourMoney.Web.Models.Banks;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Bank, BankViewModel>();
        }
    }
}