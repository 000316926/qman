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
        public string SubjectCode { get; set; }
        public string TafeCompCode { get; set; }
    }
}