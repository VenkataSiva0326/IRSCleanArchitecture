using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IRSCleanArchitecture.Application.Exceptions;
using IRSCleanArchitecture.Application.Interfaces;
using IRSCleanArchitecture.Domain.Entities;
using MediatR;

namespace IRSCleanArchitecture.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserCommandResponse>
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        //public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
        //{
        //    _unitOfWork = unitOfWork;
        //    _userRepository = userRepository;
        //    _mapper = mapper;
        //}

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.Id, cancellationToken);


            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }
            //if (user == null) throw new Exception("Usuário não encontrado");

            user.Name = request.Name;
            user.Email = request.Email;

            var validator = new UpdateUserCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            await _userRepository.UpdateUser(user);

            return _mapper.Map<UpdateUserCommandResponse>(user);
        }
    }
}
