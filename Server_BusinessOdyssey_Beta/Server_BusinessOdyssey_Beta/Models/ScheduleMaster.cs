using System;
using System.Collections.Generic;

namespace Server_BusinessOdyssey_Beta.Models
{
    public partial class ScheduleMaster
    {
        public int ScheduleMasterId { get; set; }
        public string JGroupName { get; set; }
        public string SGroupName { get; set; }
        public int ScheduleId { get; set; }

        public JudgesGroup JGroupNameNavigation { get; set; }
        public StudentGroup SGroupNameNavigation { get; set; }
        public Schedule Schedule { get; set; }
    }
}
