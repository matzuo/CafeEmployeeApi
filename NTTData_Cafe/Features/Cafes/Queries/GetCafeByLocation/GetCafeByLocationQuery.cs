using MediatR;
using NTTData_Cafe.Models.DataModels;
using NTTData_Cafe.Models.DtoModels;

namespace NTTData_Cafe.Features.Cafes.Queries.GetCafeByLocation
{
    public record GetCafeByLocationQuery(string? location) : IRequest<List<CafeDTO>>;
}
