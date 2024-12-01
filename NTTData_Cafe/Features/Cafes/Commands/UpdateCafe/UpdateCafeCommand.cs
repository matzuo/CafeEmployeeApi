using MediatR;

namespace NTTData_Cafe.Features.Cafes.Commands.UpdateCafe
{
  public class UpdateCafeCommand(Guid cafeId, string name, string description, string location, string? logo) : IRequest<bool>
  {
    public Guid CafeId { get; } = cafeId;
    public string Name { get; } = name;
    public string Description { get; } = description;
    public string Location { get; } = location;
    public string? Logo { get; } = logo;
  }
}
