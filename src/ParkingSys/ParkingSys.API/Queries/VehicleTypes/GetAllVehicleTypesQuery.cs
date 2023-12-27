using ParkingSys.API.Abstractions.Messaging;
using ParkingSys.API.Model;

namespace ParkingSys.API.Queries.VehicleTypes;

public sealed record GetAllVehicleTypesQuery : IQuery<ICollection<VehicleType>>
{
}
