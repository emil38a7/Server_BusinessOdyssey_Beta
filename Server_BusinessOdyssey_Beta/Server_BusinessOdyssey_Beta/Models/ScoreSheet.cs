using System;
using System.Collections.Generic;

namespace Server_BusinessOdyssey_Beta.Models
{
    public partial class ScoreSheet
    {
        public ScoreSheet()
        {
            Question = new HashSet<Question>();
        }

        public int ScoreSheetId { get; set; }
        public string ScoreSheetCategory { get; set; }
        public int TrackId { get; set; }

        public Track Track { get; set; }
        public ICollection<Question> Question { get; set; }
    }
}
