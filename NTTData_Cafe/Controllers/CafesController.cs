using MediatR;
using Microsoft.AspNetCore.Mvc;
using NTTData_Cafe.Features.Cafes.Commands.CreateCafe;
using NTTData_Cafe.Features.Cafes.Commands.DeleteCafe;
using NTTData_Cafe.Features.Cafes.Commands.UpdateCafe;
using NTTData_Cafe.Features.Cafes.Queries.GetCafeByLocation;
using NTTData_Cafe.Models.DataModels;

namespace NTTData_Cafe.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CafesController : ControllerBase
  {
    private readonly ISender _sender;
    public CafesController(ISender sender)
    {
      _sender = sender;
    }


    [HttpPost]
    public async Task<ActionResult<Guid>> CreateCafe(CreateCafeCommand command)
    {

      Guid cafeId = await _sender.Send(command);

      return Ok(cafeId);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCafe(Guid id , [FromBody] UpdateCafeCommand command)
    {
      if (id != command.CafeId)
      {
        return BadRequest("Cafe ID mismatch.");
      }

      var result = await _sender.Send(command);

      if (!result)
      {
        return NotFound($"Cafe with ID {id} not found.");
      }

      return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCafe(Guid id)
    {
      var result = await _sender.Send(new DeleteCafeCommand { CafeId = id });

      if (!result)
      {
        return NotFound($"Cafe with ID {id} not found.");
      }

      return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetCafeByLocation(string? location)
    {
      var cafes = await _sender.Send(new GetCafeByLocationQuery(location));

      if (cafes == null || cafes.Count == 0)
      {
        return Ok(new List<Cafe>());
      }

      return Ok(cafes);
    }

  }
}
