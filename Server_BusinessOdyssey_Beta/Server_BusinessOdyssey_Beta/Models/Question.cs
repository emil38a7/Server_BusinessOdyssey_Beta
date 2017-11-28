using System;
using System.Collections.Generic;

namespace Server_BusinessOdyssey_Beta.Models
{
    public partial class Question
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int? QuestionPoints { get; set; }
        public double? QuestionWeight { get; set; }
        public int? ScoreSheetId { get; set; }

        public ScoreSheet ScoreSheet { get; set; }
    }
}
