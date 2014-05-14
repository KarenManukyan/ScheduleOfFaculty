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
                    Id = lectLess.Id,
                    Lect = new LecturerGrid(_db.Lecturers.Find(lectLess.lecturerId)),
                    Less = new LessonGrid(_db.Lessons.Find(lectLess.lessonId)),
                    LessonType = new TypeGrid(_db.Types.Find(lectLess.typeId)),
                    Time = lectLess.Time
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
                typeId = lessLec.LessonType.Id,
                Time = lessLec.Time
            });
            _db.SaveChanges();
        }

        public void Update(LessonLecturerGrid lessLec)
        {

            JoinLessonLecturer lect = _db.JoinLessonLecturers.Find(lessLec.Id);
            lect.lecturerId = lessLec.Lect.Id;
            lect.lessonId = lessLec.Less.Id;
            lect.typeId = lessLec.LessonType.Id;
            lect.Time = lessLec.Time;
            _db.SaveChanges();
        }

        public void Destroy(int id)
        {
            JoinLessonLecturer lect = _db.JoinLessonLecturers.Find(id);
            _db.JoinLessonLecturers.Remove(lect);
            _db.SaveChanges();
        }

        public List<LessonGrid> GetLesson()
        {
            var data = _db.Lessons.Select(c => c);
            List<LessonGrid> lesson = new List<LessonGrid>();
            foreach (var less in data)
            {
                lesson.Add(new LessonGrid
                {
                    Id = less.id,
                    Name = less.name
                });
            }
            return lesson;
        }

        public List<LecturerGrid> GetLecturer()
        {
            var data = _db.Lecturers.Select(c => c);
            List<LecturerGrid> lecturer = new List<LecturerGrid>();
            foreach (var lect in data)
            {
                lecturer.Add(new LecturerGrid
                {
                    Id = lect.Id,
                    Name = lect.Name
                });
            }
            return lecturer;
        }

        public List<TypeGrid> GetTypes()
        {
            var data = _db.Types.Select(c => c);
            List<TypeGrid> lessonType = new List<TypeGrid>();
            foreach (var type in data)
            {
                lessonType.Add(new TypeGrid
                {
                    Id = type.Id,
                    Name = type.Type1
                });
            }   
            return lessonType;
        }

    }
}