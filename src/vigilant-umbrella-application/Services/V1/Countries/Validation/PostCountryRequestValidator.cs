namespace vigilant_umbrella_application.Services.V1.Countries.Validation;

using FluentValidation;
using vigilant_umbrella_application.Services.V1.Countries.Requests;

/// <summary>
/// Validator for <see cref="PostCountryRequest"/> to ensure that the request data is valid.
/// </summary>
public class PostCountryRequestValidator : AbstractValidator<PostCountryRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PostCountryRequestValidator"/> class.
    /// </summary>
    public PostCountryRequestValidator()
    {
        this.RuleFor(x => x.Code)
            .Length(2, 10).WithMessage("Code must be between 2 and 10 characters.");
    }
}