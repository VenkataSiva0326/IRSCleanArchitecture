using IRSCleanArchitecture.Application.Features.Users.Commands.CreateUser;
using IRSCleanArchitecture.Application.Features.Users.Commands.DeleteUser;
using IRSCleanArchitecture.Application.Features.Users.Commands.UpdateUser;
using IRSCleanArchitecture.Application.Features.Users.Queries.GetAllUser;
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
        public async Task<ActionResult<List<GetAllUserResponse>>> GetAll(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllUserRequest(), cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<CreateUserResponse>> Create(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateUserResponse>> Update(int? id, UpdateUserRequest request, CancellationToken cancellationToken)
        {
            if (id != request.Id) return BadRequest("Parâmetro id está incorreto");

            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteUserResponse>> Delete(int? id, CancellationToken cancellationToken)
        {
            if (id == null) return BadRequest("Id é nulo");

            var request = new DeleteUserRequest(id.Value);

            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }
    }
}
