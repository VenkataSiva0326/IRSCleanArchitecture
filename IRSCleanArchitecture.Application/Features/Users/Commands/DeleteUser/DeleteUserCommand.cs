using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRSCleanArchitecture.Application.Features.Users.Commands.CreateUser;
using MediatR;

namespace IRSCleanArchitecture.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<DeleteUserCommandResponse>
    {
        public int? Id { get; set; }
    }
}
