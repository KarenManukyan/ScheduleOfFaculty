using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScheduleOfFaculty.Models;

namespace ScheduleOfFaculty.Models
{
    public class LecturerLessonStore
    {
        private ScheduleForFacultyEntities _db;

        public LecturerLessonStore()
        {
            _db = new ScheduleForFacultyEntities();
            _db.Configuration.ProxyCreationEnabled = false;
        }
        public List<LessonLecturerGrid> Read()
        {
            var data = _db.JoinLessonLecturers.Select(c => c);
            List<LessonLecturerGrid> lessonLecturerList = new List<LessonLecturerGrid>();
            foreach (var lectLess in data)
            {
                lessonLecturerList.Add(new LessonLecturerGrid
                {
                    Id = lectLess.id,
                    Lect = new LecturerGrid(_db.lecturers.Find(lectLess.lecturerId)),
                    Less = new LessonGrid(_db.Lessons.Find(lectLess.lessonId)),
                    Time = lectLess.TimeForLecurer
                });
            }
            return lessonLecturerList;
        }

        public void Create(LessonLecturerGrid lessLec)
        {
            _db.JoinLessonLecturers.Add(new JoinLessonLecturer
            {
                lecturerId = lessLec.Lect.Id,
                lessonId = lessLec.Less.Id,
                TimeForLecurer = lessLec.Time
            });
            _db.SaveChanges();
        }

        public void Update(LessonLecturerGrid lessLec)
        {

            JoinLessonLecturer lect = _db.JoinLessonLecturers.Find(lessLec.Id);
            lect.lecturerId = lessLec.Lect.Id;
            lect.lessonId = lessLec.Less.Id;
            lect.TimeForLecurer = lessLec.Time;
            _db.SaveChanges();
        }

        public void Destroy(int id)
        {
            JoinLessonLecturer lect = _db.JoinLessonLecturers.Find(id);
            _db.JoinLessonLecturers.Remove(lect);
            _db.SaveChanges();
        }

        public IEnumerable<LessonGrid> GetLesson()
        {
            var data = _db.Lessons.Select(c => new LessonGrid
            {
                Id = c.id,
                Name = c.name
            });
            return data;
        }

        public IEnumerable<LecturerGrid> GetLecturer()
        {
            var data = _db.lecturers.Select(c => new LecturerGrid
            {
                Id = c.id,
                Name = c.name + " " + c.surname

            });
            return data;
        }
    }
}