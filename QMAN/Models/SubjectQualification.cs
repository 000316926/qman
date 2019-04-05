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
        [ForeignKey("Subject")]
        [Column(Order =1)]        
        public string SubjectCode { get; set; }
        [Key]
        [ForeignKey("Qualification")]
        [Column(Order =2)]
        public string QualCode { get; set; }
        public string CompTypeCode { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual Qualification Qualification { get; set; }
    }
}