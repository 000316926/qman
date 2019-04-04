using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QMAN.Models
{
    [Table("Crn_Detail")]
    public class CrnDetail
    {
        [Key]
        public string CRN { get; set; }
        public string TafeCompCode { get; set; }
        [Key]
        public int TermCodeStart { get; set; }
        [Key]
        public int TermYearStart { get; set; }
        public int TermCodeEnd { get; set; }
        public int TermYearEnd { get; set; }
        public string SubjectCode { get; set; }
        public string CampusCode { get; set; }
        public string LecturerID { get; set; }
        public string DepartmentCode { get; set; }
        public DateTime FreezeDate { get; set; }
        public DateTime DateCreated { get; set; }
    }
}