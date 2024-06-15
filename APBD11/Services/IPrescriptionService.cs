using APBD_11.DTO;
using APBD11.Models;

namespace APBD11.Services;

public interface IPrescriptionService
{
    public Task<Prescription> AddPrescriptionAsync(PrescriptionRequestDto request);
    
    public Task<Prescription> GetPrescriptionAsync(int id);
    
}