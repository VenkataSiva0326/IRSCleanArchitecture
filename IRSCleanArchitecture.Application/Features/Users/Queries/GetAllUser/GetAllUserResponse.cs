using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSCleanArchitecture.Application.Features.Users.Queries.GetAllUser
{
    public sealed class GetAllUserResponse
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
    }
}
