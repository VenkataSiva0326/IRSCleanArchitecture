using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IRSCleanArchitecture.Application.Interfaces;
using MediatR;

namespace IRSCleanArchitecture.Application.Features.Users.Queries.GetAllUser
{
    public sealed class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<UserListVm>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserListVm>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllUsers(cancellationToken);
            return _mapper.Map<List<UserListVm>>(users);
        }
    }
}
