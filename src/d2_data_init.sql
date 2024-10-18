.OPEN 'world_content.db'

ATTACH DATABASE 'file:d2_data.db' AS dest;

drop table if exists dest.weapons;

create table if not exists dest.weapons
(
    id                               integer not null default ROWID,
    hash                             integer not null,
    name                             text    not null,
    icon_url                         text    not null,
    watermark_url                    text    not null,
    screenshot_url                   text    not null,
    display_name                     text    not null,
    flavor_text                      text    not null,
    tier_type                        text    not null,
    ammo_type                        text    not null,
    source_string                    text    null,
    damage_type_name                 text    not null,
    damage_type_description          text    not null,
    damage_type_icon_url             text    null,
    damage_type_transparent_icon_url text    null,
    constraint weapon_pkey primary key (id)
);

create index if not exists dest.weapons_idx_hash on weapons (hash);
create index if not exists dest.weapons_idx_name on weapons (name);
create index if not exists dest.weapons_idx_display_name on weapons (display_name);
create index if not exists dest.weapons_idx_tier_type on weapons (tier_type);
create index if not exists dest.weapons_idx_ammo_type on weapons (ammo_type);
create index if not exists dest.weapons_idx_damage_type_name on weapons (damage_type_name);



insert into dest.weapons (hash, name, icon_url, watermark_url, screenshot_url, display_name, flavor_text, tier_type,
                          ammo_type, source_string, damage_type_name, damage_type_description, damage_type_icon_url,
                          damage_type_transparent_icon_url)
select json -> 'hash'                                                                   as Hash,
       json -> 'displayProperties' ->> 'name'                                           as Name,
       substr(json -> 'displayProperties' ->> 'icon', 32)                               as IconUrl,
       substr(json ->> 'iconWatermark', 32)                                             as Watermark,
       substr(json ->> 'screenshot', 38)                                                as Screenshot,
       json ->> 'itemTypeDisplayName'                                                   as DisplayName,
       json ->> 'flavorText'                                                            as FlavorText,
       json -> 'inventory' ->> 'tierTypeName'                                           as TierType,
       case json -> 'equippingBlock' ->> 'ammoType'
           when 1 then 'Primary'
           when 2 then 'Special'
           when 3 then 'Heavy'
           end                                                                          as AmmoType,
       coalesce((select json ->> 'sourceString'
                 from DestinyCollectibleDefinition dc
                 where di.json -> 'collectibleHash' = dc.json -> 'hash'), 'NULL')       as SourceString,
       coalesce((select json -> 'displayProperties' ->> 'name'
                 from DestinyDamageTypeDefinition dm
                 where di.json -> 'defaultDamageTypeHash' = dm.json -> 'hash'), 'NULL') as DamamgeTypeName,
       coalesce((select json -> 'displayProperties' ->> 'description'
                 from DestinyDamageTypeDefinition dm
                 where di.json -> 'defaultDamageTypeHash' = dm.json -> 'hash'), 'NULL') as DamamgeTypeDescription,
       coalesce((select substr(json -> 'displayProperties' ->> 'icon', 32)
                 from DestinyDamageTypeDefinition dm
                 where di.json -> 'defaultDamageTypeHash' = dm.json -> 'hash'), 'NULL') as DamamgeTypeIconUrl,
       coalesce((select substr(json ->> 'transparentIconPath', 44)
                 from DestinyDamageTypeDefinition dm
                 where di.json -> 'defaultDamageTypeHash' = dm.json -> 'hash'), 'NULL') as DamamgeTypeTransparentIconUrl
from DestinyInventoryItemDefinition di
where json -> 'itemType' = '3';


DETACH DATABASE dest;
