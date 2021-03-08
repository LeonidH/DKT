using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKT.Core.Services.Admin.dto
{
    public class RoleDTO
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public IEnumerable<AccountDTO> Accounts { get; set; }
    }
}
