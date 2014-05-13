using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScheduleOfFaculty.Models
{
    public class LessonTypeStore
    {
        private ScheduleForFacultyEntities _db;

        public LessonTypeStore()
        {
            _db = new ScheduleForFacultyEntities();
            _db.Configuration.ProxyCreationEnabled = false;
        }
        public List<LessonTypeGrid> Read()
        {
            var data = _db.JoinLessonTypes.Select(c => c);
            List<LessonTypeGrid> lessonType = new List<LessonTypeGrid>();
            foreach (var type in data)
            {
                lessonType.Add(new LessonTypeGrid
                {
                    Id = type.Id,
                    CurrentLesson = new LessonGrid(_db.Lessons.Find(type.LessonId)),
                    LessonType = new TypeGrid(_db.Types.Find(type.TypeId)),
                    Time = (int)type.Time
                });
            }   
            
            return lessonType;
        }

        public void Create(LessonTypeGrid lessonType)
        {
            _db.JoinLessonTypes.Add(new JoinLessonType
            {
                LessonId = lessonType.CurrentLesson.Id,
                TypeId = lessonType.LessonType.Id,
                Time = (int)lessonType.Time
            });
            _db.SaveChanges();
        }

        public void Update(LessonTypeGrid updatedLessonType)
        {

            JoinLessonType lessonType = _db.JoinLessonTypes.Find(updatedLessonType.Id);
            lessonType.LessonId = updatedLessonType.CurrentLesson.Id;
            lessonType.TypeId = updatedLessonType.LessonType.Id;
            lessonType.Time = updatedLessonType.Time;
            _db.SaveChanges();
        }

        public void Destroy(int id)
        {
            JoinLessonType type = _db.JoinLessonTypes.Find(id);
            _db.JoinLessonTypes.Remove(type);
            _db.SaveChanges();
        }

        public List<LessonGrid> GetLessons()
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