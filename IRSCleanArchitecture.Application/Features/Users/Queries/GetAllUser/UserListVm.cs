﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSCleanArchitecture.Application.Features.Users.Queries.GetAllUser
{
    public class UserListVm
    {
        public int Id { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
    }
}
