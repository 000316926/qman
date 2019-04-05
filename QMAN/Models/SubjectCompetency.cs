using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QMAN.Models
{
    [Table("Subject_Competency")]
    public class SubjectCompetency
    {
        [Key]
        [ForeignKey("Subject")]
        [Column(Order =1)]
        public string SubjectCode { get; set; }
        [Key]
        [ForeignKey("Competency")]
        [Column(Order = 2)]
        public string TafeCompCode { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual Competency Competency { get; set; }
    }
}