using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APBD11.Models;

[PrimaryKey(nameof(IdMedicament), nameof(IdPrescription))]
public class Prescription_Medicament
{
    public int IdMedicament { get; set; }

    public int IdPrescription { get; set; }

    [Required]
    [MaxLength(100)]
    public string Description { get; set; }

    [Required]
    public int? Dose { get; set; }
    
    [ForeignKey(nameof(IdMedicament))]
    public Medicament medicament { get; set; }
    
    [ForeignKey(nameof(IdPrescription))]
    public Prescription prescription { get; set; }
    
}