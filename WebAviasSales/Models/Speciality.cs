using System;
using System.Collections.Generic;

namespace WebTheBestCursach.Models
{
    public partial class Speciality
    {
        public Speciality()
        {
            AduccationForms = new HashSet<AduccationForm>();
            EducationFormBySpecialities = new HashSet<EducationFormBySpeciality>();
        }

        public int SpecialityId { get; set; }
        public string? SpecialityName { get; set; }
        public int? EducationFormId { get; set; }

        public virtual EducationForm? EducationForm { get; set; }
        public virtual ICollection<AduccationForm> AduccationForms { get; set; }
        public virtual ICollection<EducationFormBySpeciality> EducationFormBySpecialities { get; set; }
    }
}
