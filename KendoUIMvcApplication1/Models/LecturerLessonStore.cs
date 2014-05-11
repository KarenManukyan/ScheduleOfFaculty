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
            var data = _db.JoinLessonLecturers.Select(c=>c);
            List<LessonLecturerGrid> lessonLecturerList =new List<LessonLecturerGrid>();
            foreach (var lectLess in data)
            {
                lessonLecturerList.Add(new LessonLecturerGrid
                {
                    Id = lectLess.id,
                    Lect = _db.lecturers.Find(lectLess.lecturerId),
                    Less = _db.Lessons.Find(lectLess.lessonId),
                    Time = lectLess.TimeForLecurer
                });
            }
            return lessonLecturerList;
        }

        public void Create(LessonLecturerGrid lessLec)
        {
            _db.JoinLessonLecturers.Add(new JoinLessonLecturer
            {
                lecturerId = lessLec.Lect.id,
                lessonId = lessLec.Less.id,
                TimeForLecurer = lessLec.Time
            });
            _db.SaveChanges();
        }

        public void Update(LessonLecturerGrid lessLec)
        {

            JoinLessonLecturer lect = _db.JoinLessonLecturers.Find(lessLec.Id);
            lect.lecturerId = lessLec.Lect.id;
            lect.lessonId = lessLec.Less.id;
            lect.TimeForLecurer = lessLec.Time;
            _db.SaveChanges();
        }

        public void Destroy(int id)
        {
            JoinLessonLecturer lect = _db.JoinLessonLecturers.Find(id);
            _db.JoinLessonLecturers.Remove(lect);
            _db.SaveChanges();
        }
    }
}