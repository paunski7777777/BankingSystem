namespace YourMoney.Web.Infrastructure
{
    using AutoMapper;

    using Microsoft.AspNetCore.Mvc.Rendering;

    using YourMoney.Models;
    using YourMoney.Web.Areas.Admin.Models.Banks;
    using YourMoney.Web.Areas.Admin.Models.Deposits;
    using YourMoney.Web.Models.Deposits;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Bank, Bank>();
            this.CreateMap<Bank, BankViewModel>();
            this.CreateMap<Bank, BankDetailsViewModel>();
            this.CreateMap<Bank, SelectListItem>()
                .ForMember(dest => dest.Value,
                           opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Text,
                           opt => opt.MapFrom(src => src.Name));

            this.CreateMap<Deposit, Deposit>();
            this.CreateMap<Deposit, DetailsDepositViewModel>();
            this.CreateMap<Deposit, DepositBankDetailsViewModel>();
            this.CreateMap<Deposit, ComparedDepositViewModel>();
            this.CreateMap<Deposit, CalculatedDepositViewModel>();
            this.CreateMap<Deposit, Models.Deposits.DepositViewModel>();
            this.CreateMap<Deposit, Areas.Admin.Models.Deposits.DepositViewModel>();
        }
    }
}