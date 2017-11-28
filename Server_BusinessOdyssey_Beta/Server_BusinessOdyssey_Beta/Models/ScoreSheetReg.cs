using System;
using System.Collections.Generic;

namespace Server_BusinessOdyssey_Beta.Models
{
    public partial class ScoreSheetReg
    {
        public int ScoreSheetRegId { get; set; }
        public string SGroupName { get; set; }
        public string JGroupName { get; set; }
        public double? Points { get; set; }
        public int TrackId { get; set; }

        public JudgesGroup JGroupNameNavigation { get; set; }
        public StudentGroup SGroupNameNavigation { get; set; }
    }
}
