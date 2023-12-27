using MediatR;
using ParkingSys.API.Abstractions.Messaging;

namespace ParkingSys.API.Commands.VehicleType.CreateVehicleType;

public sealed record CreateVehicleTypeCommand(
    string Name,
    string Icon,
    double CostPerHour) : ICommand;
