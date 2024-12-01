using MediatR;
using NTTData_Cafe.Models.DataModels;

namespace NTTData_Cafe.Features.Employees.Queries.GetEmployeeById
{
    public record GetEmployeeByIdQuery(string id) : IRequest<Employee?>;
}
