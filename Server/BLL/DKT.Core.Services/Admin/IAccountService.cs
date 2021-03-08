using DKT.Core.Services.Admin.dto;
using System.Threading.Tasks;

namespace DKT.Core.Services.Admin
{
    public interface IAccountService
    {
        Task<AccountDTO> GetAccountByUsernameAsync(string username);
        Task<AccountDTO> CreateAccountAsync(AccountDTO dto, string password);
    }
}
