using FluentValidation;
using FluentValidation.Results;
using LanguageExt.Common;
using MediatR;
using Weapons.Application.WeaponFeature.EntityMappers;
using Weapons.Domain.Weapon;

namespace Weapons.Application.WeaponFeature;

public class WeaponHandler : IRequestHandler<WeaponCommand, Result<WeaponResponse>>
{
    private readonly IWeaponRepository _repository;
    private readonly IValidator<WeaponCommand> _validator;
    
    public WeaponHandler(WeaponValidator validator, IWeaponRepository repository)
    {
        _validator = validator;
        _repository = repository;
    }

    public async Task<Result<WeaponResponse>> Handle(WeaponCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            ValidationException errors = new ValidationException(validationResult.Errors);
            return new Result<WeaponResponse>(errors);
        }

        var model = MappingProfiles.MapWeaponCommandToWeaponRoot(request);
        await _repository.Create(model);
        var response = MappingProfiles.MapWeaponRootToWeaponResponse(model);
        return response;
    }
}