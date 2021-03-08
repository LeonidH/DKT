using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DKT.AdminService.Responses
{
    public class LoginResponse
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public bool Active { get; set; }
        public bool Blocked { get; set; }
        public string Token { get; set; }
    }
}
