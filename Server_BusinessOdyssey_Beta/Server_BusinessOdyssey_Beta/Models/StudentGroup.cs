using System;
using System.Collections.Generic;

namespace Server_BusinessOdyssey_Beta.Models
{
    public partial class StudentGroup
    {
        public StudentGroup()
        {
            ScheduleMaster = new HashSet<ScheduleMaster>();
            ScoreSheetReg = new HashSet<ScoreSheetReg>();
            Student = new HashSet<Student>();
        }

        public string SGroupName { get; set; }
        public int TrackId { get; set; }

        public ICollection<ScheduleMaster> ScheduleMaster { get; set; }
        public ICollection<ScoreSheetReg> ScoreSheetReg { get; set; }
        public ICollection<Student> Student { get; set; }
    }
}
