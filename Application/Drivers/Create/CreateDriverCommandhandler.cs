using MediatR;
using Domain.Drivers;
using Domain.Primitives;
using Domain.ValueObjects;
using ErrorOr;
using Domain.Routes;
using System.Reflection.Metadata;

namespace Application.Drivers.Create;

internal sealed class CreateDriverCommandHandler : IRequestHandler<CreateDriverCommand, ErrorOr<Unit>>
{

    private readonly IDriverRepository _driversRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateDriverCommandHandler(IDriverRepository driversRepository, IUnitOfWork unitOfWork)
    {
        _driversRepository = driversRepository ?? throw new ArgumentNullException(nameof(driversRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(CreateDriverCommand command, CancellationToken cancellationToken)
    {
        try
        {
            if (PhoneNumber.Create(command.PhoneNumber) is not PhoneNumber phoneNumber)
            {
                return Error.Validation("Drivers.PhoneNumber", " is not a valid phone number");
            }

            if (Address.Create(command.Country, command.Line1, command.Line2, command.City, command.State, command.ZipCode) is not Address address)
            {
                return Error.Validation("Drivers.Address", " is not a valid address");

            }


            var driver = new Driver(
                new DriversId(Guid.NewGuid()), // ID del conductor
                command.Name,
                command.LastName,
                command.Email,
                phoneNumber,
                address,
                command.Rid,
                active: true
            );

            await _driversRepository.Add(driver);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
        catch (Exception ex)
        {

            return Error.Failure("CreateDrivers.Failure", ex.Message);
        }
    }
}