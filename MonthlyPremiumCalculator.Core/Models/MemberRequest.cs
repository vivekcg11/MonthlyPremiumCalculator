using System.ComponentModel.DataAnnotations;

public class MemberRequest
{
    [Required]
    public string Name { get; set; }

    [Required]
    public int Age { get; set; }

    [Required]
    public string DateOfBirth { get; set; }

    [Required]
    public string Occupation { get; set; }

    [Required]
    public decimal DeathSumInsured { get; set; }
}