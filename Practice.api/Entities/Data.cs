using System.ComponentModel.DataAnnotations;

namespace Practice.api.Entities;

public class Data
{
    public int Id { get; set; }
    [Range(0, 100)]
    public int Age { get; set; }
    [Required]
    [StringLength(50)]
    public required String Name { get; set; }
    [Required]
    [StringLength(6)]
    public required string Gender { get; set; }
}