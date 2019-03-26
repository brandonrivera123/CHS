using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CHS_Auction_Site.Models
{
    public partial class Events
    {
        public Events()
        {
            CheckIns = new HashSet<CheckIns>();
            Packages = new HashSet<Packages>();
            Tickets = new HashSet<Tickets>();
        }

        public int EventId { get; set; }
        public string EventLocation { get; set; }
        public int EventTicketNum { get; set; }
        [DisplayFormat(DataFormatString = "{0:g}")]
        public DateTime EventStart { get; set; }
        [DisplayFormat(DataFormatString = "{0:g}")]
        public DateTime EventEnd { get; set; }
        public string EventName { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int EventGoal { get; set; }
        public string EventURL { get; set; }

        public ICollection<CheckIns> CheckIns { get; set; }
        public ICollection<Packages> Packages { get; set; }
        public ICollection<Tickets> Tickets { get; set; }
    }
}
