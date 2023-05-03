using System;
using System.Collections.Generic;

namespace WebTheBestCursach.Models
{
    public partial class EducationForm
    {
        public EducationForm()
        {
            EducationFormBySpecialities = new HashSet<EducationFormBySpeciality>();
            Specialities = new HashSet<Speciality>();
        }

        public int EducationFormId { get; set; }
        public string? EducationName { get; set; }

        public virtual ICollection<EducationFormBySpeciality> EducationFormBySpecialities { get; set; }
        public virtual ICollection<Speciality> Specialities { get; set; }
    }
}
