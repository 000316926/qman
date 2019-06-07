using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QMAN.Models
{
    [Table("StudyPlan_Subject")]
    public class StudyPlanSubject
    {
        [Key]
        [Column(Order =1)]
        public string StudyPlanCode { get; set; }
        [Key]
        [Column(Order = 2)]
        public string SubjectCode { get; set; }
        public int TimingSemester { get; set; }
        public int TimingSemesterTerm { get; set; }
    }
}