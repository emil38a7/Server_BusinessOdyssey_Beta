using System;
using System.Collections.Generic;

namespace Server_BusinessOdyssey_Beta.Models
{
    public partial class Track
    {
        public Track()
        {
            ScoreSheet = new HashSet<ScoreSheet>();
        }

        public int TrackId { get; set; }
        public string TrackName { get; set; }

        public ICollection<ScoreSheet> ScoreSheet { get; set; }
    }
}
