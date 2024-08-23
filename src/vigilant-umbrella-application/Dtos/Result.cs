using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace vigilant_umbrella_application.Dtos;

/// <summary>
/// Defines the <see cref="BaseDto" />.
/// </summary>
public class Result
{
    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="Result"/> is success.
    /// </summary>
    /// <value>
    ///   <c>true</c> if success; otherwise, <c>false</c>.
    /// </value>
    public bool Success { get; set; }
}
