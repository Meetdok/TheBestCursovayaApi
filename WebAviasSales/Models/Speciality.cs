using System;
using System.Collections.Generic;

namespace WebAviasSales
{
    public partial class Speciality
    {
        public Speciality()
        {
            AduccationForms = new HashSet<AduccationForm>();
        }

        public int SpecialityId { get; set; }
        public string? SpecialityName { get; set; }
        public int? EducationFormId { get; set; }

        public virtual EducationForm? EducationForm { get; set; }
        public virtual ICollection<AduccationForm> AduccationForms { get; set; }
    }
}
