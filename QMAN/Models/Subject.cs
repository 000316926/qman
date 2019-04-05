using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QMAN.Models
{
    [Table("Subject")]
    public class Subject
    {
        [Key]
        public string SubjectCode { get; set; }
        public string SubjectDescription { get; set; }

        public virtual ICollection<SubjectQualification> Qualifications { get; set; }
        public virtual ICollection<SubjectCompetency> Competencies { get; set; }
    }
}