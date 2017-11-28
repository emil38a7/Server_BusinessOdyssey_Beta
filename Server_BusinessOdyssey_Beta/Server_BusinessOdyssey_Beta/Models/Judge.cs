using System;
using System.Collections.Generic;

namespace Server_BusinessOdyssey_Beta.Models
{
    public partial class Judge
    {
        public int JudgeId { get; set; }
        public string JudgeName { get; set; }
        public string JGroupName { get; set; }

        public JudgesGroup JGroupNameNavigation { get; set; }
    }
}
