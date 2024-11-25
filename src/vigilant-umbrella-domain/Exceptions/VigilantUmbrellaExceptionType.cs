namespace vigilant_umbrella_domain.Exceptions;
using System.ComponentModel;

/// <summary>
/// Enumeration representing different types of exceptions that can occur in the Vigilant Umbrella domain.
/// </summary>
public enum VigilantUmbrellaExceptionType
{
    /// <summary>
    /// The requested resource could not be found.
    /// </summary>
    [Description("The requested resource could not be found.")]
    NotFoundException = 1,

    /// <summary>
    /// The request lacks valid authentication credentials.
    /// </summary>
    [Description("The request lacks valid authentication credentials.")]
    UnauthorizedException = 2,

    /// <summary>
    /// The server understood the request but refuses to authorize it.
    /// </summary>
    [Description("The server understood the request but refuses to authorize it.")]
    ForbiddenException = 3,

    /// <summary>
    /// The server could not understand the request due to invalid syntax.
    /// </summary>
    [Description("The server could not understand the request due to invalid syntax.")]
    BadRequestException = 4,

    /// <summary>
    /// The request conflicts with the current state of the server.
    /// </summary>
    [Description("The request conflicts with the current state of the server.")]
    ConflictException = 5,

    /// <summary>
    /// The server encountered an internal error and was unable to complete the request.
    /// </summary>
    [Description("The server encountered an internal error and was unable to complete the request.")]
    InternalServerErrorException = 6,

    /// <summary>
    /// The server is currently unable to handle the request due to temporary overloading or maintenance.
    /// </summary>
    [Description("The server is currently unable to handle the request due to temporary overloading or maintenance.")]
    ServiceUnavailableException = 7,

    /// <summary>
    /// An unknown error occurred while processing the request.
    /// </summary>
    [Description("An unknown error occurred while processing the request.")]
    UnknownException = 8,
}
