using AutoMapper;
using DKT.Core.Admin.BusinessObjects;

namespace DKT.Core.Services.Admin.dto.AutoMaperProfile
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleDTO, Role>()
                .ForMember(r => r.Accounts, opt => opt.MapFrom(x => x.Accounts))
                .ReverseMap();
        }
    }
}
