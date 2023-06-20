using MediatR;
using Domain.Primitives;
using ErrorOr;
using Domain.Routes;

namespace Application.Routes.Create;

internal sealed class CreateRouteCommandHandler : IRequestHandler<CreateRouteCommand, ErrorOr<Unit>>
{

    private readonly IRouteRepository _routesRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateRouteCommandHandler(IRouteRepository routesRepository, IUnitOfWork unitOfWork)
    {
        _routesRepository = routesRepository ?? throw new ArgumentNullException(nameof(routesRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(CreateRouteCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var route = new Route(
                new RoutesId(Guid.NewGuid()),
                command.Origin,
                command.Destination,
                command.Distance,
                active: true
            );

            await _routesRepository.Add(route);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
        catch (Exception ex)
        {

            return Error.Failure("CreateRoutes.Failure", ex.Message);
        }
    }
}