using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QMAN.Models
{
    [Table("Crn_Session_Timetable")]
    public class CrnSessionTimetable
    {
        [Key]
        public string Crn { get; set; }
        public int TermCodeStart { get; set; }
        public int TermYearStart { get; set; }
        public int DayCode { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Room { get; set; }
        public string Building { get; set; }
        public string CampusCode { get; set; }
    }
}