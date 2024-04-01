using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IRSCleanArchitecture.Application.Interfaces;
using MediatR;

namespace IRSCleanArchitecture.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DeleteUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.Id, cancellationToken);

            if (user == null) throw new Exception("Usuário não existe na base de dados");

            await _userRepository.DeleteUser(user);

            return _mapper.Map<DeleteUserResponse>(user);
        }
    }
}
