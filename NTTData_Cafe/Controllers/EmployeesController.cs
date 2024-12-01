using MediatR;
using Microsoft.AspNetCore.Mvc;
using NTTData_Cafe.Features.Employees.Commands.CreateEmployee;
using NTTData_Cafe.Features.Employees.Commands.DeleteEmployee;
using NTTData_Cafe.Features.Employees.Commands.UpdateEmployee;
using NTTData_Cafe.Features.Employees.Queries.GetEmployeeByCafeName;

namespace NTTData_Cafe.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmployeesController : ControllerBase
  {
    private readonly ISender _sender;

    public EmployeesController(ISender sender)
    {
      _sender = sender;
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateEmployee(CreateEmployeeCommand command) 
    {

      string employeeId = await _sender.Send(command);

      return Ok(employeeId);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(string id, [FromBody] UpdateEmployeeCommand command)
    {
      if (id != command.EmployeeID)
      {
        return BadRequest("Employee ID mismatch.");
      }

      var result = await _sender.Send(command);

      if (!result)
      {
        return NotFound($"Employee with ID {id} not found.");
      }

      return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(string id)
    {
      var result = await _sender.Send(new DeleteEmployeeCommand { EmployeeId = id });

      if (!result)
      {
        return NotFound($"Employee with ID {id} not found.");
      }

      return Ok(result);
    }

    //[HttpGet("{id}")]
    //public async Task<IActionResult> GetEmployeeById(string id)
    //{
    //  var employee = await _sender.Send(new GetEmployeeByIdQuery(id));

    //  if (employee == null)
    //  {
    //    return NotFound();
    //  }

    //  return Ok(employee);
    //}


    [HttpGet]
    public async Task<IActionResult> GetEmployeeByCafe(string? cafeName)
    {
      var employee = await _sender.Send(new GetEmployeeByCafeNameQuery(cafeName));

      if (employee == null)
      {
        return NotFound();
      }

      return Ok(employee);
    }
    
  }
}
