using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParkingSys.API.Commands.VehicleType.CreateVehicleType;
using ParkingSys.API.Dto.VehicleType;
using ParkingSys.API.Queries.VehicleTypes;

namespace ParkingSys.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehicleTypeController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpGet]
    public async Task<IActionResult> GetVehicleTypes(CancellationToken cancellationToken)
    {
        var query = new GetAllVehicleTypesQuery();
        var result = await _sender.Send(query, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> CreateVehicleType(
        CreateVehicleTypeRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateVehicleTypeCommand(request.Name, request.Icon, request.CostPerHour);
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }
}
