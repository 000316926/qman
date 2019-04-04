using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QMAN.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public string StudentID { get; set; }
        public string GivenName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}