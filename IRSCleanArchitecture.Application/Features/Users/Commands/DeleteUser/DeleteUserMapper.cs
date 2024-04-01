using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IRSCleanArchitecture.Domain.Entities;

namespace IRSCleanArchitecture.Application.Features.Users.Commands.DeleteUser
{
    public sealed class DeleteUserMapper : Profile
    {
        public DeleteUserMapper()
        {
            CreateMap<DeleteUserRequest, User>();
            CreateMap<User, DeleteUserResponse>();
        }
    }
}
