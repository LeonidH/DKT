﻿using System;
using System.Collections.Generic;

namespace DKT.Core.Services.Admin.dto
{
    public class AccountDTO
    {
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public bool Active { get; set; }
        public bool Blocked { get; set; }
        public IEnumerable<RoleDTO> Roles { get; set; }
    }
}
