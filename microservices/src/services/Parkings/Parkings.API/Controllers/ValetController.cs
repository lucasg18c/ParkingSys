using Microsoft.AspNetCore.Mvc;
using Parkings.API.Dto;
using Parkings.Domain.Repository;

namespace Parkings.API.Controllers;


[Route("api")]
[ApiController]
public class ValetController : ControllerBase
{
    private readonly IValetRepository _valetRepository;
    public ValetController(IValetRepository valetRepository)
    {
        _valetRepository = valetRepository;
    }

    [HttpGet("valet/{id}/invites")]
    public async Task<IEnumerable<ParkingInviteDto>> GetInvites(string id)
    {
        var res = await _valetRepository.GetInvites(id);

        return res.Select(i => new ParkingInviteDto
        {
            Id = i.Id,
            ParkingLot = new ParkingLotDto
            {
                Id = i.ParkingLot.Id,
                DateCreated = i.ParkingLot.DateCreated,
                Name = i.ParkingLot.Name,
                OwnerId = i.ParkingLot.OwnerId,
                DateUpdated = i.ParkingLot.DateUpdated
            },
            DateCreated = i.DateCreated,
        });
    }

    [HttpPost("valet/invite/{inviteId}")]
    public async Task<IActionResult> ProcessInvite(string inviteId, [FromQuery] bool accepted)
    {
        var res = await _valetRepository.ProcessInvite(inviteId, accepted);

        return res is null ? BadRequest() : Ok();
    }
}
