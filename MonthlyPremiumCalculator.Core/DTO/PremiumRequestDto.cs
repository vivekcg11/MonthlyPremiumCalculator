using System.ComponentModel.DataAnnotations;
public class PremiumRequestDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Age must be greater than or equal to 0")]
    public int Age { get; set; }

    [Required]
    public string DateOfBirth { get; set; }

    [Required]
    public string Occupation { get; set; }

    [Required]
    public decimal DeathSumInsured { get; set; }
}