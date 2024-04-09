using IRSCleanArchitecture.API.Extensions;
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
        public async Task<ActionResult<List<UserListVm>>> GetAll(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllUserQuery(), cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType<CreateUserCommandResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [ContentTypeValidation] // Apply the attribute to the action method
        public async Task<ActionResult<CreateUserCommandResponse>> Create(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            // Generate the URL for the newly created resource
            var baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            var locationUrl = new Uri(baseUrl + "/api/Users/" + response.Id.ToString());

            // Return the response with 201 Created status code and Location header
            return Created(locationUrl, response.Id);

            //return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<UpdateUserCommandResponse>> Update(int? id, UpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (id != request.Id) return BadRequest("Parâmetro id está incorreto");

            await _mediator.Send(request, cancellationToken);

            return NoContent();
            //var response = await _mediator.Send(request, cancellationToken);
            
            //return Ok(response);
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
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetUserByIdQueryResponse>> GetByid(int? id, CancellationToken cancellationToken)
        {
            if (id == null) return NotFound("Id is Not found");

            var request = new GetUserByIdQueryRequest(id.Value);

            var response = await _mediator.Send(request, cancellationToken);

            return response == null ? NotFound() : Ok(response);
        }
    }
}
