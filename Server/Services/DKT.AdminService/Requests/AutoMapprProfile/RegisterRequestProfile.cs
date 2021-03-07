using AutoMapper;
using DKT.Core.Services.Admin.dto;
using Server.Requests;
using System;

namespace DKT.AdminService.Requests.AutoMapprProfile
{
    public class RegisterRequestProfile : Profile
    {
        public RegisterRequestProfile()
        {
            CreateMap<RegisterRequest, AccountDTO>()
                .ForMember(dist => dist.Active, opt => opt.MapFrom(x => true))
                .ForMember(dist => dist.Created, opt => opt.MapFrom(x => DateTime.UtcNow));
        }
    }
}
