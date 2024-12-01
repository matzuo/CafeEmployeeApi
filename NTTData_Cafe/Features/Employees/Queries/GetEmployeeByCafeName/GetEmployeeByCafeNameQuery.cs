using MediatR;
using NTTData_Cafe.Models.DtoModels;

namespace NTTData_Cafe.Features.Employees.Queries.GetEmployeeByCafeName
{
  public record GetEmployeeByCafeNameQuery(string cafeName) : IRequest<List<EmployeeDTO>>;
}
