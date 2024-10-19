using LanguageExt.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Weapons.Application.Contexts;
using Weapons.Application.GetAllWeapons.Mappers;
using Weapons.Application.Interfaces;
using Weapons.Domain.Weapon;

namespace Weapons.Application.GetAllWeapons;

public class GetAllWeaponsHandler : IRequestHandler<GetAllWeaponsQuery, Result<PagedResponse<GetAllWeaponsResponse>>>
{
    private readonly IWeaponRepository _repository;

    public GetAllWeaponsHandler(IWeaponRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<PagedResponse<GetAllWeaponsResponse>>> Handle(GetAllWeaponsQuery request, CancellationToken cancellationToken)
    {
        var page = request.Page ?? 1;
        var pageSize = request.PageSize ?? 10;
        
        var offset = (page - 1) * pageSize;
        var (rows, totalRows) = await _repository.GetAllWeaponsAsync(page, pageSize, offset);
        var totalPages = (int)Math.Ceiling(totalRows / (double)pageSize);
        return new PagedResponse<GetAllWeaponsResponse>
        {
            Page = page,
            PageSize = pageSize,
            Count = totalRows,
            TotalPages = totalPages,
            Data = rows.Select(MapWeaponRootToGetAllWeaponsResponse.Map)
        };
    }
}