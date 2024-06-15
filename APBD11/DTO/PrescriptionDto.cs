namespace APBD_11.DTO;

public class PrescriptionDto
{
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public List<PrescriptionMedicamentDto> Medicaments { get; set; }
}