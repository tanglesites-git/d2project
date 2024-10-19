namespace Weapons.Application;

public static class QueryGateway
{
    public const string GetAllWeapons = """
                                        SELECT
                                          id as Id, 
                                          hash as Hash, 
                                          name as Name, 
                                          icon_url as IconUrl, 
                                          watermark_url as WatermarkUrl, 
                                          screenshot_url as ScreenshotUrl, 
                                          display_name as DisplayName ,
                                          flavor_text as FlavorText, 
                                          tier_type as TierType, 
                                          ammo_type as AmmoType, 
                                          source_string as Source, 
                                          damage_type_name as DamageTypeName,
                                          damage_type_description as DamageTypeDescription, 
                                          damage_type_icon_url as DamageTypeIconUrl, 
                                          damage_type_transparent_icon_url as DamageTypeTransparentIconUrl
                                        FROM weapons limit @Limit offset @Offset;
                                        
                                          select count(*) from weapons;
                                        """;
}