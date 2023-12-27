using ParkingSys.API.Abstractions.Results;

namespace ParkingSys.API.Commands.VehicleType.CreateVehicleType;

public static class CreateVehicleTypeErrors
{
    public static readonly Error NameRequired = new("VehicleType.Create.NameRequired", "Name is required");
}
