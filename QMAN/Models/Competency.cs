using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QMAN.Models
{
    [Table("Competency")]
    public class Competency
    {
        [Key]
        public string TafeCompCode { get; set; }
        public string NationalCompCode { get; set; }
        public string CompetencyName { get; set; }
        public int Hours { get; set; }

        public virtual ICollection<SubjectCompetency> Subjects { get; set; }
    }
}