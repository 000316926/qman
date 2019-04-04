using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QMAN.Models
{
    [Table("Student_Grade")]
    public class StudentGrade
    {
        [Key]
        public string StudentID { get; set; }
        [Key]
        public string Crn { get; set; }
        [Key]
        public int TermCode { get; set; }
        [Key]
        public int TermYear { get; set; }
        public string Grade { get; set; }
        public DateTime GradeDate { get; set; }
    }
}