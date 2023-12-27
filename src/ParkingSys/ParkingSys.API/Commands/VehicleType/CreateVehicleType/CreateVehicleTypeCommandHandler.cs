using ParkingSys.API.Abstractions.Messaging;
using ParkingSys.API.Abstractions.Results;
using ParkingSys.API.Repository;

namespace ParkingSys.API.Commands.VehicleType.CreateVehicleType;

internal sealed class CreateVehicleTypeCommandHandler : ICommandHandler<CreateVehicleTypeCommand>
{
    public async Task<Result> Handle(CreateVehicleTypeCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return CreateVehicleTypeErrors.NameRequired;
        }

        VehicleTypeRepository.VehicleTypeList.Add(new Model.VehicleType
        {
            CostPerHour = request.CostPerHour,
            Icon = request.Icon,
            Name = request.Name,
        });

        return Result.Success();
    }
}
