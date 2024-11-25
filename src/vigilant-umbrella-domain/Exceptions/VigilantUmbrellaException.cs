namespace vigilant_umbrella_domain.Exceptions;

using System;

/// <summary>
/// Represents errors that occur during application execution in the Vigilant Umbrella domain.
/// </summary>
public class VigilantUmbrellaException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VigilantUmbrellaException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public VigilantUmbrellaException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="VigilantUmbrellaException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
    public VigilantUmbrellaException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="VigilantUmbrellaException"/> class.
    /// </summary>
    public VigilantUmbrellaException() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="VigilantUmbrellaException"/> class with a specified error message and error code.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="code">The code that represents the error.</param>
    public VigilantUmbrellaException(string message, string code) : base(message)
    {
        Code = code;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="VigilantUmbrellaException"/> class with a specified exception type.
    /// </summary>
    /// <param name="exceptionType">The type of the exception.</param>
    public VigilantUmbrellaException(VigilantUmbrellaExceptionType exceptionType) : base(GetDescription(exceptionType))
    {
        Code = ((int)exceptionType).ToString();
    }

    /// <summary>
    /// Gets or sets the code that represents the error.
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        return $"Code: {Code}, Message: {Message}";
    }

    /// <summary>
    /// Gets a message that describes the current exception.
    /// </summary>
    public override string Message => $"Code: {Code}, Message: {base.Message}";

    /// <summary>
    /// Gets the description attribute of the specified exception type.
    /// </summary>
    /// <param name="exceptionType">The type of the exception.</param>
    /// <returns>The description of the exception type.</returns>
    private static string GetDescription(VigilantUmbrellaExceptionType exceptionType)
    {
        var type = exceptionType.GetType();
        var memInfo = type.GetMember(exceptionType.ToString());
        var attributes = memInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
        return ((System.ComponentModel.DescriptionAttribute)attributes[0]).Description;
    }
}
