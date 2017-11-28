using System;
using System.Collections.Generic;

namespace Server_BusinessOdyssey_Beta.Models
{
    public partial class JudgesGroup
    {
        public JudgesGroup()
        {
            Judge = new HashSet<Judge>();
            ScheduleMaster = new HashSet<ScheduleMaster>();
            ScoreSheetReg = new HashSet<ScoreSheetReg>();
        }

        public string JGroupName { get; set; }
        public string JGroupKey { get; set; }

        public ICollection<Judge> Judge { get; set; }
        public ICollection<ScheduleMaster> ScheduleMaster { get; set; }
        public ICollection<ScoreSheetReg> ScoreSheetReg { get; set; }
    }
}
