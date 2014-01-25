using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScheduleOfFaculty.Models
{
    public class DbManager
    {
        private schedulOfFacultyEntities _db;

        public DbManager() 
        {
            this._db = new schedulOfFacultyEntities();
            _db.Configuration.ProxyCreationEnabled = false;
        }

        public IEnumerable<LecturerGrid> GetLecturer(int id)
        {
            var data = from lect in _db.lecturers
                       from less in _db.lessonForLecturers
                       from qual in _db.qualifications
                       where (less.lessonId == id && lect.id == less.lecturerId) &&
                       (lect.qualificationId == qual.id)
                       select new LecturerGrid
                       {
                           Id = lect.id,
                           Name = lect.name,
                           Surname = lect.surname,
                           Birthday = lect.birthday,
                           Qualification = qual.name
                       };
            
            return data;
        }

        public IEnumerable<LessonGrid> GetLessons()
        {
            var data = from l in _db.lessons
                       join t in _db.types on l.typeId equals t.id
                       select new LessonGrid
                       {
                           Id = l.id,
                           Name =l.name,
                           Time = l.time,
                           Type = t.type1
                       };
            
            return data;
        }

        public login GetCurrentUserLogin(string UserName, string Password)
        {
            login log = (from user in _db.logins
                         where user.login1 == UserName && user.password == Password
                         select user).Single<login>();
            return log;
        }


        public lecturer GetCurrentUser(int id)
        {
            lecturer teacher = (from user in _db.lecturers
                                where user.id == id 
                                select user).Single<lecturer>();
            return teacher;
        }
    }
}