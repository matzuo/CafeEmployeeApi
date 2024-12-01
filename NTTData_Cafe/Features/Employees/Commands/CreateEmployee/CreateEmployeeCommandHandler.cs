using MediatR;
using NTTData_Cafe.Data;
using NTTData_Cafe.Helpers;
using NTTData_Cafe.Models.DataModels;

namespace NTTData_Cafe.Features.Employees.Commands.CreateEmployee
{
  public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, string>
  {
    private readonly NTTDataDbContext _context;

    public CreateEmployeeCommandHandler(NTTDataDbContext context)
    {
      _context = context;
    }

    public async Task<string> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
      var employee = new Employee
      {
        EmployeeID = CommonHelper.GenerateUniqueId(),
        StartDate = DateTime.Now,
        PhoneNumber = request.PhoneNumber,
        Gender = request.Gender,
        FullName = request.FullName,
        Email = request.Email,
        CafeId = request.CafeId
      };

      _context.Employees.Add(employee);
      
      await _context.SaveChangesAsync(cancellationToken);

      return employee.EmployeeID;
    }
  }
}
