using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QMAN.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public string DepartmentCode { get; set; }
        [Column("Description")]
        public string DepartmentName { get; set; }
    }
}