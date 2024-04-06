using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IRSCleanArchitecture.Application.Features.Users.Commands.DeleteUser;
using IRSCleanArchitecture.Application.Interfaces;
using MediatR;

namespace IRSCleanArchitecture.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQueryRequest, UserDetailsVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserDetailsVm> Handle(GetUserByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var userByIdResponse = await _userRepository.GetUserById(request.Id, cancellationToken);

            //if (userByIdResponse == null) throw new Exception("The Given User details not found");

            return _mapper.Map<UserDetailsVm>(userByIdResponse);
        }
    }
}
