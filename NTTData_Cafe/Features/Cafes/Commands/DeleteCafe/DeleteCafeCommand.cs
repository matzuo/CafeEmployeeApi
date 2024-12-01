using MediatR;

namespace NTTData_Cafe.Features.Cafes.Commands.DeleteCafe
{
  public class DeleteCafeCommand : IRequest<bool>
  {
    public Guid CafeId { get; set; }
  }
}
