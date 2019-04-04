using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QMAN.Models
{
    [Table("Term_DateTime")]
    public class TermDateTime
    {
        [Key]
        public int TermCode { get; set; }
        [Key]
        public int TermYear { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SemesterCode { get; set; }
    }
}