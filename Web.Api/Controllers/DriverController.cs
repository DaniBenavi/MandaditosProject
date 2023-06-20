using Application.Drivers.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers;

[Route("Drivers")]
public class Driverss : ApiController
{
    private readonly ISender _mediator;

    public Driverss(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDriverCommand command)
    {
        var createDriversResult = await _mediator.Send(command);

        return createDriversResult.Match(
            Drivers => Ok(),
            errors => Problem(errors)
        );
    }
}