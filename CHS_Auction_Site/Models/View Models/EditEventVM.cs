using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHS_Auction_Site.Models
{
    public class EditEventVM
    {
        public IEnumerable<Events> CurrentEvents { get; set; }

        public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventLocation { get; set; }
        public int EventTicketNum { get; set; }
        public int EventGoal { get; set; }
        public DateTime EventStart { get; set; }
        public DateTime EventEnd { get; set; }
        public string EventURL { get; set; }
    }
}
