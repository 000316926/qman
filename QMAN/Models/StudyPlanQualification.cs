using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QMAN.Models
{
    [Table("StudyPlan_Qualification")]
    public class StudyPlanQualification
    {
        [Key]
        public string StudyPlanCode { get; set; }
        public string QualCode { get; set; }
        public int Priority { get; set; }
    }
}