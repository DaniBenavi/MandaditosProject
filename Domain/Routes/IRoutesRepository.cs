namespace Domain.Routes;

public interface IRouteRepository
{
    Task<Route?> GetByIdAsync(RoutesId id);
    Task Add(Route route);
}