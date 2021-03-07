using AutoMapper;
using DKT.Core.Admin.BusinessObjects;

namespace DKT.Core.Services.Admin.dto.AutoMaperProfile
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<AccountDTO, Account>().ReverseMap();
        }
    }
}
