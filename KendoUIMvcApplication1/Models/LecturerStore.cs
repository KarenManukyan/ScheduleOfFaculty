using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScheduleOfFaculty.Models;

namespace ScheduleOfFaculty.Models
{
    public class LecturerStore
    {
        private ScheduleForFacultyEntities _db;

        public LecturerStore()
        {
            _db = new ScheduleForFacultyEntities();
            _db.Configuration.ProxyCreationEnabled = false;
        }
        public IEnumerable<lecturer> Read()
        {
            var data = _db.lecturers.Select(c => c);
            return data;
        }

        public void Create(lecturer lect)
        {
            _db.lecturers.Add(lect);
            _db.SaveChanges();
        }

        public void Update(lecturer updatedlect)
        {

            lecturer lect = _db.lecturers.Find(updatedlect.id);
            lect.name = updatedlect.name;
            lect.surname = updatedlect.surname;
            lect.patromic = updatedlect.patromic;
            //lect.birthday = updatedlect.birthday;
            lect.qualification = updatedlect.qualification;
            _db.SaveChanges();
        }

        public void Destroy(int id)
        {
            lecturer lect = _db.lecturers.Find(id);
            _db.lecturers.Remove(lect);
            _db.SaveChanges();
        }
    }
}