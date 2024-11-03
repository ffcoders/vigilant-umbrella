using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace vigilant_umbrella_application.Dtos;

/// <summary>
/// Defines the <see cref="BaseDto"/>.
/// </summary>
public class BaseDto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
}
