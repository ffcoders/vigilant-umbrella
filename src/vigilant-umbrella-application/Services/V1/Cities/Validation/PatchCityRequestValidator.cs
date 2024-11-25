namespace vigilant_umbrella_application.Services.V1.Cities.Validation;

using FluentValidation;
using vigilant_umbrella_application.Services.V1.Cities.Requests;

/// <summary>
/// Validator for <see cref="PatchCityRequest"/> to ensure that the request data is valid.
/// </summary>
public class PatchCityRequestValidator : AbstractValidator<PatchCityRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PatchCityRequestValidator"/> class.
    /// </summary>
    public PatchCityRequestValidator()
    {
        RuleFor(x => x.FieldsToUpdate)
            .NotEmpty().WithMessage("FieldsToUpdate is required.");

        When(x => !string.IsNullOrEmpty(x.Code), () =>
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Code is required.")
                .Length(2, 10).WithMessage("Code must be between 2 and 10 characters.");
        });
    }
}