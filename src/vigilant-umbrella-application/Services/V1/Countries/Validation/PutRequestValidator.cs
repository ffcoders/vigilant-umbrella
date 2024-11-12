namespace vigilant_umbrella_application.Services.V1.Countries.Validation;

using FluentValidation;
using vigilant_umbrella_application.Services.V1.Countries.Requests;

/// <summary>
/// Validator for <see cref="PutRequest"/> to ensure that the request data is valid.
/// </summary>
public class PutRequestValidator : AbstractValidator<PutRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PutRequestValidator"/> class.
    /// </summary>
    public PutRequestValidator()
    {
        this.RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Code is required.")
            .Length(2, 10).WithMessage("Code must be between 2 and 10 characters.");
    }
}
