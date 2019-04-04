using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QMAN.Models
{
    [Table("Subject_Qualification")]
    public class SubjectQualification
    {
        [Key]
        public string SubjectCode { get; set; }
        [Key]
        public string QualCode { get; set; }
        public string CompTypeCode { get; set; }
    }
}