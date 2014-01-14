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
        }

        public IEnumerable<lecturer> GetLecturer()
        {
            _db.Configuration.ProxyCreationEnabled = false;
            var data = _db.lecturers;
            return data;
        }

        public IEnumerable<lesson> GetLessons()
        {
            _db.Configuration.ProxyCreationEnabled = false;
            var data = _db.lessons.ToList<lesson>();
            return data;
        }


    }
}