using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QMAN.Models
{
    [Table("Lecturer")]
    public class Lecturer
    {
        [Key]
        public string LecturerID { get; set; }
        public string GivenName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}