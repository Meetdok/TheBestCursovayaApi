using System;
using System.Collections.Generic;

namespace WebAviasSales
{
    public partial class EducationForm
    {
        public EducationForm()
        {
            Specialities = new HashSet<Speciality>();
        }

        public int EducationFormId { get; set; }
        public string? EducationName { get; set; }

        public virtual ICollection<Speciality> Specialities { get; set; }
    }
}
