using ParkingSys.API.Abstractions.Messaging;
using ParkingSys.API.Abstractions.Results;
using ParkingSys.API.Model;
using ParkingSys.API.Repository;

namespace ParkingSys.API.Queries.VehicleTypes;

internal sealed class GetAllVehicleTypesQueryHandler : IQueryHandler<GetAllVehicleTypesQuery, ICollection<VehicleType>>
{
    public async Task<Result<ICollection<VehicleType>>> Handle(
        GetAllVehicleTypesQuery request, 
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        return Result<ICollection<VehicleType>>.Success(VehicleTypeRepository.VehicleTypeList);
    }
}