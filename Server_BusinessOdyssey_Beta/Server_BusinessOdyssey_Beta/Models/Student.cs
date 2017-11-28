using System;
using System.Collections.Generic;

namespace Server_BusinessOdyssey_Beta.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentSchool { get; set; }
        public string SGroupName { get; set; }

        public StudentGroup SGroupNameNavigation { get; set; }
    }
}
