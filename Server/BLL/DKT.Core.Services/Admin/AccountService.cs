using AutoMapper;
using DKT.Admin.Helpers;
using DKT.Core.Admin.BusinessObjects;
using DKT.Core.Services.Admin.dto;
using DKT.Data.EntityFramework;
using System.Linq;
using System.Threading.Tasks;

namespace DKT.Core.Services.Admin
{
    public class AccountService : IAccountService
    {
        private readonly AdminDbContext _adminDbContext;
        private readonly IMapper _mapper;

        public AccountService(AdminDbContext adminDbContext, IMapper mapper)
        {
            _adminDbContext = adminDbContext;
            _mapper = mapper;
        }
        public AccountDTO GetAccountByUsername(string username) => _mapper.Map<AccountDTO>(_adminDbContext.Accounts.FirstOrDefault(a => a.Username == username));

        public async Task<AccountDTO> CreateAccountAsync(AccountDTO dto, string password)
        {
            HashingHelper.CreateAccountPasswordHash(password, out var passwordHash, out var passwordSalt);
            dto.PasswordHash = passwordHash;
            dto.PasswordSalt = passwordSalt;
            var entity = await _adminDbContext.Accounts.AddAsync(_mapper.Map<Account>(dto));
            await _adminDbContext.SaveChangesAsync();
            return _mapper.Map<AccountDTO>(entity.Entity);
        }

    }
}
