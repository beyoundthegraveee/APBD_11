using APBD11.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD11.Context;

public partial class DatabaseContext : DbContext
{

    public DatabaseContext()
    {

    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }
    public DbSet<Doctor> Doctors { get; set; }

    public DbSet<Medicament> Medicaments { get; set; }

    public DbSet<Patient> Patients { get; set; }

    public DbSet<Prescription> Prescriptions { get; set; }

    public DbSet<Prescription_Medicament> PrescriptionMedicaments { get; set; }
    
    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Prescription_Medicament>()
            .HasKey(pm => new { pm.IdMedicament, pm.IdPrescription });
        
        modelBuilder.Entity<Doctor>().HasData(
            new Doctor { IdDoctor = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" },
            new Doctor { IdDoctor = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com" }
        );
        
        modelBuilder.Entity<Patient>().HasData(
            new Patient { IdPatient = 1, FirstName = "Alice", LastName = "Johnson", BirthDate = new DateTime(1980, 1, 1) },
            new Patient { IdPatient = 2, FirstName = "Bob", LastName = "Williams", BirthDate = new DateTime(1990, 2, 2) }
        );
        
        modelBuilder.Entity<Medicament>().HasData(
            new Medicament { IdMedicament = 1, MedicamentName = "MedicamentA", MedicamentDescription = "DescriptionA", Type = "TypeA" },
            new Medicament { IdMedicament = 2, MedicamentName = "MedicamentB", MedicamentDescription = "DescriptionB", Type = "TypeB" }
        );
        
        modelBuilder.Entity<Prescription>().HasData(
            new Prescription { IdPresctiprion = 1, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(30), IdPatient = 1, IdDoctor = 1 },
            new Prescription { IdPresctiprion = 2, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(30), IdPatient = 2, IdDoctor = 2 }
        );

    }

}