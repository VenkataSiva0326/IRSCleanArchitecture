using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IRSCleanArchitecture.Application.Interfaces;
using IRSCleanArchitecture.Domain.Entities;
using MediatR;

namespace IRSCleanArchitecture.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            var createdUser = await _userRepository.CreateUser(user);

            return _mapper.Map<CreateUserResponse>(createdUser);
        }
    }
}
