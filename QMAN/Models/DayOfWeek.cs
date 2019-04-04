using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QMAN.Models
{
    [Table("Day_Of_Week")]
    public class DayOfWeek
    {
        [Key]
        public int DayCode { get; set; }
        [Key]
        public string DayShortName { get; set; }
        public string DayLongName { get; set; }
    }
}