using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QMAN.Models
{
    [Table("Qualification")]
    public class Qualification
    {
        [Key]
        public string QualCode { get; set; }
        public string NationalQualCode { get; set; }
        public string TafeQualCode { get; set; }
        public string QualName { get; set; }
        public int TotalUnits { get; set; }
        public int CoreUnits { get; set; }
        public int ElectedUnits { get; set; }
        public int ReqListedElectedUnits { get; set; }

        public virtual ICollection<SubjectQualification> Subjects { get; set; }
        public virtual ICollection<StudyPlanQualification> StudyPlans { get; set; }
    }
}