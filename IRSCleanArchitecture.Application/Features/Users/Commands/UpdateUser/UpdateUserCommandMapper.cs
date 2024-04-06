using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IRSCleanArchitecture.Domain.Entities;

namespace IRSCleanArchitecture.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandMapper : Profile
    {
        public UpdateUserCommandMapper()
        {
            CreateMap<UpdateUserCommand, User>();
            CreateMap<User, UpdateUserCommandResponse>();
        }
    }
}
