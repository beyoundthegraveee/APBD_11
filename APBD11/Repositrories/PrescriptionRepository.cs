using APBD_11.DTO;
using APBD11.Context;
using APBD11.Models;
using APBD11.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APBD11.Repositrories;

public class PrescriptionRepository:IPrescriptionService
{

    private readonly DatabaseContext _databaseContext;


    public PrescriptionRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    [HttpPost]
   public async Task<Prescription> AddPrescriptionAsync(PrescriptionRequestDto request)
    {
        using var transaction = await _databaseContext.Database.BeginTransactionAsync();
        try
        {
            var patient = await _databaseContext.Patients
                .FirstOrDefaultAsync(p => p.FirstName == request.Patient.FirstName &&
                                          p.LastName == request.Patient.LastName &&
                                          p.BirthDate == request.Patient.Birthdate);
            if (patient == null)
            {
                patient = new Patient
                {
                    FirstName = request.Patient.FirstName,
                    LastName = request.Patient.LastName,
                    BirthDate = request.Patient.Birthdate
                };
                _databaseContext.Patients.Add(patient);
                await _databaseContext.SaveChangesAsync();
            }

            var doctor = await _databaseContext.Doctors
                .FirstOrDefaultAsync(d => d.FirstName == request.Doctor.FirstName &&
                                          d.LastName == request.Doctor.LastName &&
                                          d.Email == request.Doctor.Email);
            if (doctor == null)
            {
                doctor = new Doctor
                {
                    FirstName = request.Doctor.FirstName,
                    LastName = request.Doctor.LastName,
                    Email = request.Doctor.Email
                };
                _databaseContext.Doctors.Add(doctor);
                await _databaseContext.SaveChangesAsync();
            }

            var prescription = new Prescription
            {
                Date = request.Prescription.Date,
                DueDate = request.Prescription.DueDate,
                IdPatient = patient.IdPatient,
                IdDoctor = doctor.IdDoctor,
                PrescriptionMedicaments = new List<Prescription_Medicament>()
            };

            foreach (var tmp in request.Prescription.Medicaments)
            {
                var medicament = await _databaseContext.Medicaments.FindAsync(tmp.IdMedicament);
                if (medicament == null)
                {
                    throw new Exception($"Medicament with Id {tmp.IdMedicament} does not exist.");
                }

                Prescription_Medicament pm = new Prescription_Medicament
                {
                    IdMedicament = tmp.IdMedicament,
                    Dose = tmp.Dose,
                    Description = tmp.Description
                };

                prescription.PrescriptionMedicaments.Add(pm);
            }

            _databaseContext.Prescriptions.Add(prescription);
            await _databaseContext.SaveChangesAsync();

            await transaction.CommitAsync();

            return prescription;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw new Exception("Failed to add prescription.", ex);
        }
    }
   

    public async Task<Prescription> GetPrescriptionAsync(int id)
    {
        return await _databaseContext.Prescriptions
            .Include(p => p.Patient)
            .Include(p => p.Doctor)
            .Include(p => p.PrescriptionMedicaments)
            .ThenInclude(pm => pm.medicament)
            .FirstOrDefaultAsync(p => p.IdPresctiprion == id);
    }
}