using Domain.Drivers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class DriverRepository : IDriverRepository
{

    private readonly ApplicationDbContext _context;

    public DriverRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Add(Driver driver) => await _context.Drivers.AddAsync(driver);

    public async Task<Driver?> GetByIdAsync(DriversId id) => await _context.Drivers.SingleOrDefaultAsync(c => c.Id == id);

}