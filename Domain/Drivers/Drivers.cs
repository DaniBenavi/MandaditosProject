using Domain.Primitives;
using Domain.Routes;
using Domain.ValueObjects;

namespace Domain.Drivers;

public sealed class Driver : AgregateRoot
{
    public Driver(DriversId id, string name, string lastName, string email, PhoneNumber phoneNumber, Address address, RoutesId rid, bool active)
    {
        Id = id;
        Name = name;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Address = address;
        Routeid = rid;
        Active = active;
    }

    private Driver()
    {

    }

    public DriversId Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string FullName => $"{Name} {LastName}";
    public string Email { get; private set; } = string.Empty;
    public PhoneNumber PhoneNumber { get; private set; }
    public Address Address { get; private set; }
    public RoutesId Routeid { get; private set; }
    public bool Active { get; private set; }
}