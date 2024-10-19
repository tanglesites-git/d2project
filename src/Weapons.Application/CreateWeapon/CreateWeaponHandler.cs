using FluentValidation;
using LanguageExt.Common;
using MediatR;
using Weapons.Application.CreateWeapon.Mappers;
using Weapons.Application.Interfaces;

namespace Weapons.Application.CreateWeapon;

public class CreateWeaponHandler : IRequestHandler<CreateWeaponCommand, Result<CreateWeaponResponse>>
{
    private readonly IWeaponRepository _repository;
    private readonly IValidator<CreateWeaponCommand> _validator;
    
    public CreateWeaponHandler(CreateWeaponValidator validator, IWeaponRepository repository)
    {
        _validator = validator;
        _repository = repository;
    }

    public async Task<Result<CreateWeaponResponse>> Handle(CreateWeaponCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            ValidationException errors = new ValidationException(validationResult.Errors);
            return new Result<CreateWeaponResponse>(errors);
        }

        var model = MapCreateWeaponCommandToWeaponRoot.Map(request);
        await _repository.Create(model);
        var response = MapWeaponRootToCreateWeaponResponse.Map(model);
        return response;
    }
}