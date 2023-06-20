using Domain.Primitives;

namespace Domain.Routes;

public sealed class Route : AgregateRoot
{
    public Route(RoutesId id, string origin, string destination, string distance, bool active)
    {
        Id = id;
        Origin = origin;
        Destination = destination;
        Distance = distance;
        Active = active;
    }

    private Route()
    {

    }

    public RoutesId Id { get; private set; }
    public string Origin { get; private set; } = string.Empty;
    public string Destination { get; private set; } = string.Empty;
    public string Distance { get; private set; } = string.Empty;
    public bool Active { get; private set; }
}