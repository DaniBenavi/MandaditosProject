namespace Domain.Drivers;

public interface IDriverRepository
{
    Task<Driver?> GetByIdAsync(DriversId id);
    Task Add(Driver driver);
}