using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace IRSCleanArchitecture.Application.Features.Users.Queries.GetAllUser
{
    public sealed record class GetAllUserRequest : IRequest<List<GetAllUserResponse>>
    {
    }
}
