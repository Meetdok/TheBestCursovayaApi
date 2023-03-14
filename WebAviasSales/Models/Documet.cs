using System;
using System.Collections.Generic;

namespace WebAviasSales
{
    public partial class Documet
    {
        public Documet()
        {
            AduccationForms = new HashSet<AduccationForm>();
        }

        public int DocumetId { get; set; }
        public DateTime? BirthdayDate { get; set; }
        public string? BirthPlace { get; set; }
        public int? Snils { get; set; }
        public int? Inn { get; set; }
        public string? Addres { get; set; }
        public string? Nationality { get; set; }
        public int? PassSeries { get; set; }
        public int? PassNumber { get; set; }
        public string? IssuedBy { get; set; }
        public string? LastName { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<AduccationForm> AduccationForms { get; set; }
    }
}
