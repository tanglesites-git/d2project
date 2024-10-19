namespace Weapons.Application.GetAllWeapons.Mappers;

public static class MapPageRequestToPageGetAllWeaponsQuery
{
    public static GetAllWeaponsQuery Map(PageRequest request)
    {
        return new GetAllWeaponsQuery
        {
            PageSize = request.PageSize,
            Page = request.Page,
        };
    }
}