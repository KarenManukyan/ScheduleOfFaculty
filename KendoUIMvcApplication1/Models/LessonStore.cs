using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScheduleOfFaculty.Models;

namespace ScheduleOfFaculty.Models
{
    public class LessonStore
    {
        private ScheduleForFacultyEntities _db;

        public LessonStore()
        {
            _db = new ScheduleForFacultyEntities();
            _db.Configuration.ProxyCreationEnabled = false;
        }

        public IEnumerable<Lesson> Read()
        {
            var data = _db.Lessons.Select(c => c);
            return data;
        }

        public void Create(Lesson less)
        {
            _db.Lessons.Add(less);
            _db.SaveChanges();
        }

        public void Update(Lesson updatedLesson)
        {
            Lesson less = _db.Lessons.Find(updatedLesson.id);
            less.name = updatedLesson.name;
            less.time = updatedLesson.time;
            less.type = updatedLesson.type;
            _db.SaveChanges();
        }

        public void Destroy(int id)
        {
            Lesson less = _db.Lessons.Find(id);
            _db.Lessons.Remove(less);
            _db.SaveChanges();
        }

    }
}