//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QMAN
{
    using System;
    using System.Collections.Generic;
    
    public partial class crn_session_timetable
    {
        public string CRN { get; set; }
        public int TermCodeStart { get; set; }
        public int TermYearStart { get; set; }
        public int DayCode { get; set; }
        public System.TimeSpan StartTime { get; set; }
        public System.TimeSpan EndTime { get; set; }
        public string Room { get; set; }
        public string Building { get; set; }
        public string CampusCode { get; set; }
    
        public virtual campus campus { get; set; }
        public virtual crn_detail crn_detail { get; set; }
        public virtual day_of_week day_of_week { get; set; }
        public virtual term_datetime term_datetime { get; set; }
    }
}
