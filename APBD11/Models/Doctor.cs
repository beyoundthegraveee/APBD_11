﻿using System.ComponentModel.DataAnnotations;

namespace APBD11.Models;

public class Doctor
{
    [Key]
    [Required]
    public int IdDoctor { get; set;}

    [Required] [MaxLength(100)] public string FirstName { get; set; }

    [Required] [MaxLength(100)] public string LastName { get; set; }

    [Required] [MaxLength(100)] public string Email { get; set; }
    
    public virtual ICollection<Prescription> Prescriptions { get; set; }



}