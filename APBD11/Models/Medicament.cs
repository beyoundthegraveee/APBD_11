using System.ComponentModel.DataAnnotations;

namespace APBD11.Models;

public class Medicament
{
    [Key]
    public int IdMedicament { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string MedicamentName { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string MedicamentDescription { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Type { get; set; }
}