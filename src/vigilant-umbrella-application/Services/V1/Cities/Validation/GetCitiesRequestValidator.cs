namespace vigilant_umbrella_application.Services.V1.Cities.Validation;

using FluentValidation;
using vigilant_umbrella_application.Services.V1.Cities.Requests;

/// <summary>
/// Validator for <see cref="GetCitiesRequest"/> to ensure that the request data is valid.
/// </summary>
public class GetCitiesRequestValidator : AbstractValidator<GetCitiesRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetCitiesRequestValidator"/> class.
    /// </summary>
    public GetCitiesRequestValidator()
    {
        RuleFor(x => x.Code)
            .MaximumLength(10).WithMessage("Code must be at most 10 characters long.");
    }
}
