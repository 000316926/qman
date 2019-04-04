using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QMAN.Models
{
    [Table("Campus")]
    public class Campus
    {
        [Key]
        public string CampusCode { get; set; }
        public string CampusName { get; set; }
    }
}