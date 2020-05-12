using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfCodeFirst.Model
{
    public class Mitarbeiter : Person
    {
        [Required]
        [MaxLength(76)]
        public string Beruf { get; set; }
        public ICollection<Kunde> Kunde { get; set; } = new HashSet<Kunde>();
        public ICollection<Abteilung> Abteilungen { get; set; } = new HashSet<Abteilung>();

        public DateTime MitgliedSeit { get; set; }

    }
}
