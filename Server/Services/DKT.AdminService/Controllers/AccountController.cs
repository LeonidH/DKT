using AutoMapper;
using DKT.Admin.Helpers;
using DKT.AdminService.Options;
using DKT.AdminService.Requests;
using DKT.AdminService.Responses;
using DKT.Core.Services.Admin;
using DKT.Core.Services.Admin.dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Server.Requests;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ApiController
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly AuthOptions _authOptions;
        public AccountController(IAccountService accountService, IMapper mapper, IOptions<AuthOptions> authOptions)
        {
            _accountService = accountService;
            _mapper = mapper;
            _authOptions = authOptions.Value;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync(LoginRequest request)
        {
            var account = await _accountService.GetAccountByUsernameAsync(request.Username);

            if (account == null) return null;

            var passwordHash = HashingHelper.GeneratePasswordHash(request.Password, account.PasswordSalt);

            if (account.PasswordHash != passwordHash) return null;
            
            if(true) return 

            return Ok(new LoginResponse()
            {
                Username = account.Username,
                FirstName = account.FirstName,
                LastName = account.LastName,
                Created = account.Created,
                Email = account.Email,
                Active = account.Active,
                Blocked = account.Blocked,
                Token = TokenHelper.GenerateToken(account.AccountId.ToString(), account.Blocked.ToString())
            });
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

        //private ClaimsIdentity GetIdentity(string username, string password)
        //{
        //    if (person != null)
        //    {
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
        //            new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role)
        //        };
        //        ClaimsIdentity claimsIdentity =
        //        new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
        //            ClaimsIdentity.DefaultRoleClaimType);
        //        return claimsIdentity;
        //    }

        //    // если пользователя не найдено
        //    return null;
        //}


        //private JwtSecurityToken GetJwtToken()
    }
}
