using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QMAN.Models
{
    [Table("Competency_Type")]
    public class CompetencyType
    {
        [Key]
        public string CompTypeCode { get; set; }
        public string CompTypeDescription { get; set; }
    }
}