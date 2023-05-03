using System;
using System.Collections.Generic;

namespace WebTheBestCursach.Models
{
    public partial class EducationFormBySpeciality
    {
        public int EducationFormBySpecialitiesId { get; set; }
        public int EducationFormId { get; set; }
        public int? SpecialityId { get; set; }

        public virtual EducationForm EducationForm { get; set; } = null!;
        public virtual Speciality? Speciality { get; set; }
    }
}
