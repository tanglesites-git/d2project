using FluentValidation;

namespace Weapons.Application.CreateWeapon;

public class CreateWeaponValidator : AbstractValidator<CreateWeaponCommand>
{
    public CreateWeaponValidator()
    {
        ValidateName();
        ValidateAmmoType();
        ValidateIconUrl();
        ValidateWatermarkUrl();
        ValidateScreenshotUrl();
        ValidateDisplayName();
        ValidateFlavorText();
        ValidateTierType();
        ValidateSource();
        ValidateDamageTypeName();
        ValidateDamageTypeIconUrl();
        ValidateDamageTypeTransparentIconUrl();
    }

    private void ValidateName()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("Name cannot be empty");
    }

    private void ValidateIconUrl()
    {
        RuleFor(x => x.IconUrl).NotEmpty().WithMessage("IconUrl cannot be empty");
        RuleFor(x => x.IconUrl).Must(CheckThatUrlIsImage).WithMessage("IconUrl must be an image");
    }
    
    private void ValidateWatermarkUrl()
    {
        RuleFor(x => x.WatermarkUrl).NotEmpty().WithMessage("WatermarkUrl cannot be empty");
        RuleFor(x => x.WatermarkUrl).Must(CheckThatUrlIsImage).WithMessage("WatermarkUrl must be an image");
    }

    private void ValidateScreenshotUrl()
    {
        RuleFor(x => x.ScreenshotUrl).NotEmpty().WithMessage("ScreenshotUrl cannot be empty");
        RuleFor(x => x.ScreenshotUrl).Must(CheckThatUrlIsImage).WithMessage("ScreenshotUrl must be an image");
    }

    private void ValidateDisplayName()
    {
        RuleFor(x => x.DisplayName).NotEmpty().WithMessage("DisplayName cannot be empty");
        RuleFor(x => x.DisplayName).Must(CheckThatDisplayNameIsOneOf).WithMessage("DisplayName must be one of the following: ['Rocket Launcher','Submachine Gun','Hand Cannon','Sniper Rifle','Grenade Launcher','Sidearm','Shotgun','Machine Gun','Scout Rifle','Auto Rifle','Pulse Rifle','Fusion Rifle','Linear Fusion Rifle','Sword','Glaive','Trace Rifle','Combat Bow']");
    }

    private void ValidateFlavorText()
    {
        RuleFor(x => x.FlavorText).NotNull().WithMessage("FlavorText cannot be null");
    }

    private void ValidateTierType()
    {
        RuleFor(x => x.TierType).NotEmpty().WithMessage("TierType cannot be empty");
        RuleFor(x => x.TierType).Must(CheckThatTierTypeIsOneOf);
    }

    private void ValidateAmmoType()
    {
        RuleFor(x => x.AmmoType).NotEmpty().WithMessage("AmmoType cannot be empty");
        RuleFor(x => x.AmmoType).Must(CheckThatAmmoTypeIsOneOf);
    }

    private void ValidateSource()
    {
        RuleFor(x => x.Source).NotEmpty().WithMessage("Source cannot be empty");
        RuleFor(x => x.Source).NotNull().WithMessage("Source cannot be empty");
    }

    private void ValidateDamageTypeName()
    {
        RuleFor(x => x.DamageTypeName).NotEmpty().WithMessage("DamageTypeName cannot be empty");
        RuleFor(x => x.DamageTypeName).Must(CheckIfDamageTypeIsOneOf);
    }

    private void ValidateDamageTypeIconUrl()
    {
        RuleFor(x => x.DamageTypeIconUrl).NotEmpty().WithMessage("DamageTypeIconUrl cannot be empty");
        RuleFor(x => x.DamageTypeIconUrl).Must(CheckThatUrlIsImage).WithMessage("DamageTypeIconUrl must be an image");

    }
    
    private void ValidateDamageTypeTransparentIconUrl()
    {
        RuleFor(x => x.DamageTypeTransparentIconUrl).NotEmpty().WithMessage("DamageTypeTransparentIconUrl cannot be empty");
        RuleFor(x => x.DamageTypeTransparentIconUrl).Must(CheckThatUrlIsImage).WithMessage("DamageTypeTransparentIconUrl must be an image");

    }
    
    
    // Implementations
    private static bool CheckThatUrlIsImage(string url)
    {
        var split = url.Split(".").Last();
        return split is "png" or "jpg";
    }

    private static bool CheckThatDisplayNameIsOneOf(string name)
    {
        return name is "Rocket Launcher" or "Submachine Gun" or "Hand Cannon" or "Sniper Rifle" or "Grenade Launcher"
            or "Sidearm" or "Shotgun" or "Machine Gun" or "Scout Rifle" or "Auto Rifle" or "Pulse Rifle"
            or "Fusion Rifle" or "Linear Fusion Rifle" or "Sword" or "Glaive" or "Trace Rifle" or "Combat Bow";
    }

    private static bool CheckThatTierTypeIsOneOf(string name)
    {
        return name is "Legendary" or "Rare" or "Common" or "Uncommon" or "Exotic";
    }

    private static bool CheckThatAmmoTypeIsOneOf(string name)
    {
        return name is "Heavy" or "Primary" or "Special";
    }

    private static bool CheckIfDamageTypeIsOneOf(string name)
    {
        return name is "Arc" or "Kinetic" or "Void" or "Strand" or "Stasis" or "Raid" or "Solar";
    }
}