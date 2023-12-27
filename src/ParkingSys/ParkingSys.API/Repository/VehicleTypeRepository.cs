using ParkingSys.API.Model;

namespace ParkingSys.API.Repository;

// todo: replace wwith real service
public static class VehicleTypeRepository
{
    public static ICollection<VehicleType> VehicleTypeList { get; set; } = new List<VehicleType>();
}
