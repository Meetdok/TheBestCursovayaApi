using System;
using System.Collections.Generic;

namespace WebAviasSales
{
    public partial class AduccationForm
    {
        public int DefaultListId { get; set; }
        public string? PatronicName { get; set; }
        public int? SpecialityId { get; set; }
        public int? DocumentsId { get; set; }
        public int? UserId { get; set; }
        public string? PrimingCertificate { get; set; }
        public string? RegistrationCertificate { get; set; }
        public string? MedicalPolicy { get; set; }
        public string? Fluorography { get; set; }

        public virtual Documet? Documents { get; set; }
        public virtual Speciality? Speciality { get; set; }
        public virtual User? User { get; set; }
    }
}
