namespace vigilant_umbrella_application.Services.V1.Countries.Validation;

using FluentValidation;
using vigilant_umbrella_application.Services.V1.Countries.Requests;

/// <summary>
/// Validator for <see cref="GetCountriesRequest"/> to ensure that the request data is valid.
/// </summary>
public class GetCountriesRequestValidator : AbstractValidator<GetCountriesRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetCountriesRequestValidator"/> class.
    /// </summary>
    public GetCountriesRequestValidator()
    {
        this.RuleFor(x => x.Code)
            .MaximumLength(10).WithMessage("Code must be at most 10 characters long.");
    }
}
