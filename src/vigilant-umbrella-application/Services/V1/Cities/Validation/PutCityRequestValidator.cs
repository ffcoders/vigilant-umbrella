namespace vigilant_umbrella_application.Services.V1.Cities.Validation;

using FluentValidation;
using vigilant_umbrella_application.Services.V1.Cities.Requests;

/// <summary>
/// Validator for <see cref="PutCityRequest"/> to ensure that the request data is valid.
/// </summary>
public class PutCityRequestValidator : AbstractValidator<PutCityRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PutCityRequestValidator"/> class.
    /// </summary>
    public PutCityRequestValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Code is required.")
            .Length(2, 10).WithMessage("Code must be between 2 and 10 characters.");
    }
}
