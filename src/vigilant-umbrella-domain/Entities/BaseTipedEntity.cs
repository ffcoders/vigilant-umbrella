namespace vigilant_umbrella_domain.Entities;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Defines the <see cref="BaseTipedEntity"/>.
/// </summary>
public class BaseTipedEntity
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the code.
    /// </summary>
    /// <value>
    /// The code.
    /// </value>
    public required string Code { get; set; }
}
