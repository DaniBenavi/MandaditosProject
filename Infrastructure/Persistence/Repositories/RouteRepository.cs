
using Domain.Routes;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class RouteRepository : IRouteRepository
{

    private readonly ApplicationDbContext _context;

    public RouteRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Add(Route route) => await _context.Routes.AddAsync(route);

    public async Task<Route?> GetByIdAsync(RoutesId id) => await _context.Routes.SingleOrDefaultAsync(c => c.Id == id);

}