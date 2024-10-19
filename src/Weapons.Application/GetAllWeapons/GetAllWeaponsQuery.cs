using LanguageExt.Common;
using MediatR;
using Weapons.Domain.Weapon;

namespace Weapons.Application.GetAllWeapons;

public class GetAllWeaponsQuery : IRequest<Result<PagedResponse<GetAllWeaponsResponse>>>
{
    public int? Page { get; init; } = 1;
    public int? PageSize { get; init; } = 10;
}