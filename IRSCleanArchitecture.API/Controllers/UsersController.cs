using IRSCleanArchitecture.Application.Features.Users.Commands.CreateUser;
using IRSCleanArchitecture.Application.Features.Users.Commands.DeleteUser;
using IRSCleanArchitecture.Application.Features.Users.Commands.UpdateUser;
using IRSCleanArchitecture.Application.Features.Users.Queries.GetAllUser;
using IRSCleanArchitecture.Application.Features.Users.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IRSCleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAllUserQueryResponse>>> GetAll(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllUserQuery(), cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType<CreateUserCommandResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreateUserCommandResponse>> Create(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateUserCommandResponse>> Update(int? id, UpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (id != request.Id) return BadRequest("Parâmetro id está incorreto");

            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteUserCommandResponse>> Delete(int? id, CancellationToken cancellationToken)
        {
            if (id == null) return BadRequest("Id é nulo");

            var request = new DeleteUserCommand() { Id = id };

            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType<GetUserByIdQueryResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        public async Task<ActionResult<GetUserByIdQueryResponse>> GetByid(int? id, CancellationToken cancellationToken)
        {
            if (id == null) return NotFound("Id is Not found");

            var request = new GetUserByIdQueryRequest(id.Value);

            var response = await _mediator.Send(request, cancellationToken);

            return response == null ? NotFound() : Ok(response);
        }
    }
}
