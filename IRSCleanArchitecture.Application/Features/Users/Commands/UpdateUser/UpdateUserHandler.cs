using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IRSCleanArchitecture.Application.Interfaces;
using MediatR;

namespace IRSCleanArchitecture.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.Id, cancellationToken);

            if (user == null) throw new Exception("Usuário não encontrado");

            user.Name = request.Name;
            user.Email = request.Email;

            await _userRepository.UpdateUser(user);

            return _mapper.Map<UpdateUserResponse>(user);
        }
    }
}
