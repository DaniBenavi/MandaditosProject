using Application.Routes.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers;

[Route("Route")]
public class Routes : ApiController
{
    private readonly ISender _mediator;

    public Routes(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRouteCommand command)
    {
        var createRouteResult = await _mediator.Send(command);

        return createRouteResult.Match(
            Route => Ok(),
            errors => Problem(errors)
        );
    }
}