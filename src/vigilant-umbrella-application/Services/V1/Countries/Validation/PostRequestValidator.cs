namespace vigilant_umbrella_application.Services.V1.Countries.Requests;

using FluentValidation;

/// <summary>
/// Validator for <see cref="PostRequest"/> to ensure that the request data is valid.
/// </summary>
public class PostRequestValidator : AbstractValidator<PostRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PostRequestValidator"/> class.
    /// </summary>
    public PostRequestValidator()
    {
        this.RuleFor(x => x.Code)
            .Length(2, 10).WithMessage("Code must be between 2 and 10 characters.");
    }
}