using FluentValidation.Results;

namespace Weapons.Application;

public record ValidationFailed(IEnumerable<ValidationFailure> Errors)
{
    public ValidationFailed(ValidationFailure error) : this(new[] { error })
    {
        
    }
}