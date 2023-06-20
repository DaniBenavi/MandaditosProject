using Domain.Routes;
using ErrorOr;
using MediatR;


namespace Application.Drivers.Create;

public record CreateDriverCommand(
    string Name,
    string LastName,
    string Email,
    string PhoneNumber,
    string Country,
    string Line1,
    string Line2,
    string City,
    string State,
    string ZipCode,
    RoutesId Rid
) : IRequest<ErrorOr<Unit>>;