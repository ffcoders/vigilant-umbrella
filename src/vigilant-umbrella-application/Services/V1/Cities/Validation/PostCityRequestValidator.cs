namespace vigilant_umbrella_application.Services.V1.Cities.Validation;

using FluentValidation;
using vigilant_umbrella_application.Services.V1.Cities.Requests;

/// <summary>
/// Validator for <see cref="PostCityRequest"/> to ensure that the request data is valid.
/// </summary>
public class PostCityRequestValidator : AbstractValidator<PostCityRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PostCityRequestValidator"/> class.
    /// </summary>
    public PostCityRequestValidator()
    {
        RuleFor(x => x.Code)
            .Length(2, 10).WithMessage("Code must be between 2 and 10 characters.");
    }
}