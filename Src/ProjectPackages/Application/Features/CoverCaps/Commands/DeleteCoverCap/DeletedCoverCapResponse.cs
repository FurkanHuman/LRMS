// this file was created automatically.

using Core.Application.Dtos;

namespace Application.Features.CoverCaps.Commands.DeleteCoverCap;

public class DeletedCoverCapResponse : IDto
{
    public byte Id { get; set; }
    public string Name { get; set; }
}
