using MediatR;

namespace NTTData_Cafe.Features.Cafes.Commands.CreateCafe
{
  public class CreateCafeCommand(string name, string description, string location, string? logo) : IRequest<Guid>
  {
    public string Name { get; } = name;
    public string Description { get; } = description;
    public string Location { get; } = location;
    public string? Logo { get; } = logo;
  }
}
