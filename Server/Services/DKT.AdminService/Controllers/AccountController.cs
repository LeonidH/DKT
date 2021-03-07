using AutoMapper;
using DKT.Core.Services.Admin;
using DKT.Core.Services.Admin.dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Requests;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        public AccountController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Registe")]
        public async Task<IActionResult> RegisteAsync(RegisterRequest request)
        {
            var dto = _mapper.Map<AccountDTO>(request);
            var account = await _accountService.CreateAccountAsync(dto, request.Password);
            return Ok(account);
        }
    }
}
