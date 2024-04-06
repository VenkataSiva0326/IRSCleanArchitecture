using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRSCleanArchitecture.Application.Features.Users.Commands.DeleteUser;
using MediatR;

namespace IRSCleanArchitecture.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<UpdateUserCommandResponse>
    {
        public int? Id { get; set; }
        public string Email { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

    }
}
