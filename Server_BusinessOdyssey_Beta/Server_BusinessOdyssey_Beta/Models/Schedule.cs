using System;
using System.Collections.Generic;

namespace Server_BusinessOdyssey_Beta.Models
{
    public partial class Schedule
    {
        public Schedule()
        {
            ScheduleMaster = new HashSet<ScheduleMaster>();
        }

        public int ScheduleId { get; set; }
        public TimeSpan ScheduleHour { get; set; }

        public ICollection<ScheduleMaster> ScheduleMaster { get; set; }
    }
}
