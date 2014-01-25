using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScheduleOfFaculty.Models
{
    public class LessonGrid
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Time { get; set; }
        public string Type { get; set; }
    }
    public class LecturerGrid
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public System.DateTime Birthday { get; set; }
        public string Qualification { get; set; }
    }
}