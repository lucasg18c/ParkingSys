using Microsoft.AspNetCore.Mvc;
using Parkings.API.Dto;
using Parkings.Domain.Repository;

namespace Parkings.API.Controllers;

[Route("api")]
[ApiController]
public class ParkingLotController : ControllerBase
{
    private readonly IParkingLotRepository _parkingRepository;
    public ParkingLotController(IParkingLotRepository parkingRepository)
    {
        _parkingRepository = parkingRepository;
    }

    [HttpGet("parkinglots")]
    public async Task<ICollection<ParkingLotForListDto>> GetParkings()
    {
        var res = await _parkingRepository.GetAll();

        return res.Select(p => new ParkingLotForListDto
        {
            Id = p.Id,
            DateCreated = p.DateCreated,
            Name = p.Name,
            OwnerId = p.OwnerId,
            DateUpdated = p.DateUpdated
        }).ToList();
    }

    [HttpGet("parkinglot/{id}")]
    public async Task<ActionResult<ParkingLotDto?>> GetById(string id)
    {
        var res = await _parkingRepository.GetById(id);

        if (res is null)
        {
            return NotFound();
        }

        return new ParkingLotDto
        {
            Id = res.Id,
            DateCreated = res.DateCreated,
            Name = res.Name,
            OwnerId = res.OwnerId,
            DateUpdated = res.DateUpdated
        };
    }

    [HttpPost("parkinglot")]
    public async Task<ParkingLotDto> Create([FromQuery] string ownerId, [FromQuery] string name)
    {
        var created = await _parkingRepository.Create(ownerId, name);

        return new ParkingLotDto
        {
            Id = created.Id,
            DateCreated = created.DateCreated,
            Name = created.Name,
            OwnerId = created.OwnerId,
            DateUpdated = created.DateUpdated
        };
    }

    [HttpPost("parkinglot/{parkingLotId}/invite/{valetEmail}")]
    public async Task<IActionResult> InviteValet(string parkingLotId, string valetEmail)
    {
        var res = await _parkingRepository.InviteValet(parkingLotId, valetEmail);

        return res is null ? BadRequest() : Ok();
    }

    [HttpGet("parkinglot/{parkingLotId}/valets")]
    public async Task<IEnumerable<ValetForListDto>> GetValets(string parkingLotId)
    {
        var valets = await _parkingRepository.GetCurrentMembers(parkingLotId);

        return valets.Select(v => new ValetForListDto
        {
            Id = v.Id,
            Email = v.Email,
            LastName = v.LastName,
            Name = v.Name
        });
    }
}
