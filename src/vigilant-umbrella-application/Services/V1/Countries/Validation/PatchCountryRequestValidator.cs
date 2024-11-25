namespace vigilant_umbrella_application.Services.V1.Countries.Validation;

using FluentValidation;
using vigilant_umbrella_application.Services.V1.Countries.Requests;

/// <summary>
/// Validator for <see cref="PatchCountryRequest"/> to ensure that the request data is valid.
/// </summary>
public class PatchCountryRequestValidator : AbstractValidator<PatchCountryRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PatchCountryRequestValidator"/> class.
    /// </summary>
    public PatchCountryRequestValidator()
    {
        this.RuleFor(x => x.FieldsToUpdate)
            .NotEmpty().WithMessage("FieldsToUpdate is required.");

        this.When(x => !string.IsNullOrEmpty(x.Code), () =>
        {
            this.RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Code is required.")
                .Length(2, 10).WithMessage("Code must be between 2 and 10 characters.");
        });
    }
}