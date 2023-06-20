using ErrorOr;
using MediatR;


namespace Application.Routes.Create;

public record CreateRouteCommand(
    string Origin,
    string Destination,
    string Distance,
    bool Active
) : IRequest<ErrorOr<Unit>>;