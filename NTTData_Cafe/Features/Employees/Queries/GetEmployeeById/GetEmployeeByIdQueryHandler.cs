using MediatR;
using NTTData_Cafe.Data;
using NTTData_Cafe.Models.DataModels;

namespace NTTData_Cafe.Features.Employees.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee?>
  {
    private readonly NTTDataDbContext _context;

    public GetEmployeeByIdQueryHandler(NTTDataDbContext context)
    {
      _context = context;
    }

    public async Task<Employee?> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
      var employee = await _context.Employees.FindAsync(request.id);
      return employee;
    }
  }
}
