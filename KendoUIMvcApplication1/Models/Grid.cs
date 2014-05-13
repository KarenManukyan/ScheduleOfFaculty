using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScheduleOfFaculty.Models
{
    public class LessonGrid
    {
        public LessonGrid() { }
        public LessonGrid(Lesson less)
        {
            this.Id = less.id;
            this.Name = less.name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class LecturerGrid
    {
        public LecturerGrid() { }
        public LecturerGrid(lecturer lect)
        {
            this.Id = lect.id;
            this.Name = lect.name + " " + lect.surname;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }


    public class TypeGrid
    {
        public TypeGrid() { }
        public TypeGrid(Type type)
        {
            this.Id = type.Id;
            this.Name = type.Type1;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class LessonLecturerGrid
    {
        public int Id { get; set; }
        public LessonGrid Less { get; set; }
        public LecturerGrid Lect { get; set; }
        public int Time { get; set; }
    }

    public class LessonTypeGrid
    {
        public int Id { get; set; }
        public LessonGrid CurrentLesson { get; set; }
        public TypeGrid LessonType { get; set; }
        public int Time { get; set; }
    }
}